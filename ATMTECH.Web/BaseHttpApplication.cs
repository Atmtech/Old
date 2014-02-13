using System.Web;
using ATMTECH.Common;
using ATMTECH.DAO;
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

        public void Configure()
        {
            ConfigureAutofac();
            ConfigurerWebFormsMvp(ContainerProvider.ApplicationContainer);
        }


        public void DisplayFatalError(System.Exception exception)
        {
            DAOLogException daoLogException = new DAOLogException();
            LogException logException = new LogException();
            logException.InnerId = "INTERNAL";
            logException.Page = Utils.Web.Pages.GetCurrentUrl() + Utils.Web.Pages.GetCurrentPage();
            logException.Description = exception.Message + " => BaseHttpApplication";
            logException.StackTrace = exception.StackTrace;

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
                    Response.Redirect("~/Errors/Error404.htm");
                    return;
                }
            }


            Response.Redirect("~/Errors/Error.htm");
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

    }
}
