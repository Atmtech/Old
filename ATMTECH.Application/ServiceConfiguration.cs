using System.Configuration;
using ATMTECH.DAO.SessionManager;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.Wcf;
using Autofac.Integration.Web;

namespace ATMTECH.ApplicationConfiguration
{
    public class ServiceConfiguration
    {
        private static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        public void Configure()
        {
            ConfigureConnectionString();
            ConfigureAutofac();
        }

        private void ConfigureConnectionString()
        {
            DatabaseSessionManager.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        private void ConfigureAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();
            ConfigurationSettingsReader configuration = new ConfigurationSettingsReader();
            builder.RegisterModule(configuration);
            _containerProvider = new ContainerProvider(builder.Build());
            AutofacHostFactory.Container = _containerProvider.ApplicationContainer;
        }
    }
}
