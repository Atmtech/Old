using System;
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
            DAOLogException daoLogException = new DAOLogException();
            LogException logException = new LogException
                {
                    InnerId = "INTERNAL",
                    Page = Utils.Web.Pages.GetCurrentUrl() + Utils.Web.Pages.GetCurrentPage(),
                    Description = exception.Message + " => BaseHttpApplication",
                    StackTrace = exception.StackTrace
                };

            // Lorsque l'on a une erreur de session probablement que le httpModuleSessionManager n'est pas loadé correctement. Il faut mettre iis express
            if (Session["Internal_LoggedUser"] != null)
            {
                User user = (User)Session["Internal_LoggedUser"];
                logException.User = user;
            }

            daoLogException.CreateLog(logException);

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
            Utils.Debug.WriteDebug("********************************************************************************************************");
        }

    }
}
