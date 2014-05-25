using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using ATMTECH.Common;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Web;
using WebFormsMvp.Binder;
using Autofac.Integration.Wcf;
using File = ATMTECH.Entities.File;

namespace ATMTECH.Web
{
    public class BaseHttpApplication : HttpApplication
    {
        private static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        public DateTime StartDate { get; set; }
        public string Start { get; set; }

        public void Configure()
        {
            ConfigureAutofac();
            ConfigurerWebFormsMvp(ContainerProvider.ApplicationContainer);
        }


        public void DisplayFatalError(System.Exception exception)
        {
            Server.ClearError();

            if (exception is HttpException)
            {
                HttpException httpException = (HttpException)exception;
                if (httpException.GetHttpCode() == 404)
                {
                    Response.Redirect(@"~/Errors/Error404.htm");
                    return;
                }
            }

            
            Response.Redirect(@"~/Errors/Error.htm");
        }

        public void LogFile(System.Exception exception)
        {
            StreamWriter log = !System.IO.File.Exists(Server.MapPath("Errorlogfile.log")) ? new StreamWriter(Server.MapPath("Errorlogfile.log")) : System.IO.File.AppendText(Server.MapPath("Errorlogfile.log"));
            log.WriteLine("==============================================================================");
            log.WriteLine("Heure:" + DateTime.Now);
            log.WriteLine("Exception:" + exception.Message);
            log.WriteLine("Stack:" + exception.StackTrace);
            log.WriteLine("==============================================================================");
            log.Close();
        }

        private void logExceptionDatabase(System.Exception exception)
        {
            try
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(exception, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                DAOLogException daoLogException = new DAOLogException();
                LogException logException = new LogException
                {
                    InnerId = "INTERNAL",
                    Page = Utils.Web.Pages.GetCurrentUrl() + Utils.Web.Pages.GetCurrentPage(),
                    Description = exception.Message + " => BaseHttpApplication",
                    StackTrace = "Line number: " + line + "            " + exception.StackTrace
                };

                // Lorsque l'on a une erreur de session probablement que le httpModuleSessionManager n'est pas loadé correctement. Il faut mettre iis express
                if (Session["Internal_LoggedUser"] != null)
                {
                    User user = (User)Session["Internal_LoggedUser"];
                    logException.User = user;
                }

                daoLogException.CreateLog(logException);
            }
            catch (System.Exception ex)
            {
                LogFile(ex);
            }
          
        }

        private void ConfigureAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();

            ConfigurationSettingsReader configuration = new ConfigurationSettingsReader();
            builder.RegisterModule(configuration);
            _containerProvider = new ContainerProvider(builder.Build());
            AutofacHostFactory.Container = _containerProvider.ApplicationContainer;
        }

        private void ConfigurerWebFormsMvp(IContainer container)
        {
            _containerProvider = new ContainerProvider(container);
            PresenterBinder.DiscoveryStrategy = new PresenterPropertyDiscoveryStrategy();
            PresenterBinder.Factory = new AutofacPresenterFactory(container);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            StartDate = DateTime.Now;
            Start = DateTime.Now + " " + DateTime.Now.Millisecond;
            DatabaseSessionManager.DatabaseTransactionCount = 0;
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            DateTime endDate = DateTime.Now;
            string end = DateTime.Now + " " + DateTime.Now.Millisecond;
            TimeSpan diffResult = endDate - Convert.ToDateTime(StartDate);

            Utils.Debug.WriteDebug("********************************************************************************************************");
            Utils.Debug.WriteDebug("Session-Start: " + Start);
            Utils.Debug.WriteDebug("Session-End: " + end);
            Utils.Debug.WriteDebug("Difference: " + diffResult.Milliseconds.ToString() + "ms");
            Utils.Debug.WriteDebug("DatabaseTransactionCount: " + DatabaseSessionManager.DatabaseTransactionCount);
            Utils.Debug.WriteDebug("ConnectionString: " + DatabaseSessionManager.ConnectionString);
            Utils.Debug.WriteDebug("********************************************************************************************************");

            if (DatabaseSessionManager.Session.State == System.Data.ConnectionState.Open)
                DatabaseSessionManager.Session.Close();
        }

    }
}
