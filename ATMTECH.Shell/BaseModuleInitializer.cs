using System;
using System.Linq;
using System.Reflection;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using Autofac;
using Module = Autofac.Module;

namespace ATMTECH.Shell
{
    public abstract class BaseModuleInitializer : Module
    {
        public ContainerBuilder Container { get; set; }

        public void AddDependency<TInterface, TInstance>() where TInstance : TInterface
        {
            Container.RegisterType<TInstance>().As<TInterface>().PropertiesAutowired();
        }
        public abstract void InitDependency();

        private void InitService()
        {
            Assembly dataAccess = GetType().Assembly;
            Container.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .SingleInstance();
        }
        private void InitDao()
        {
            Assembly dataAccess = VerificationEtForcerloadAssembly();

            if (dataAccess != null)
            {
                Container.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.Contains("DAO"))
                   .AsImplementedInterfaces()
                   .PropertiesAutowired();
            }
        }
        private void InitializeFramework()
        {
            AddDependency<IParameterService, ParameterService>();
            AddDependency<IAuthenticationService, AuthenticationService>();
            AddDependency<IMailService, MailService>();
            AddDependency<IMessageService, MessageService>();
            AddDependency<INavigationService, NavigationService>();
            AddDependency<ILogService, LogService>();
            AddDependency<IDAOGroupUser, DAOGroupUser>();
            AddDependency<IDAOUser, DAOUser>();
            AddDependency<IDAOLogVisit, DAOLogVisit>();
            AddDependency<IDAOLogException, DAOLogException>();
            AddDependency<IDAOMessage, DAOMessage>();
            AddDependency<IDAOParameter, DAOParameter>();
            AddDependency<IWeatherService, WeatherService>();
        }
        private Assembly VerificationEtForcerloadAssembly()
        {
            string assemblyName = (GetType().Assembly.GetName().Name).Replace(".Services", "") + ".DAO";
            return
                AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == assemblyName) ??
                ChercherAssemblyReferencer(assemblyName);
        }
        private Assembly ChercherAssemblyReferencer(string assemblyName)
        {
            AssemblyName assemblyReferencer =
                GetType().Assembly.GetReferencedAssemblies().FirstOrDefault(a => a.Name == assemblyName);

            return assemblyReferencer != null ? Assembly.Load(assemblyReferencer) : null;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            Container = builder;
            InitDependency();
            InitializeFramework();
            InitDao();
            InitService();
        }
    }


}

