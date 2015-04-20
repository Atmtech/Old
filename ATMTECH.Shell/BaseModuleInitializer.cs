using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ATMTECH.Services;
using ATMTECH.Services.Interface;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Module = Autofac.Module;

namespace ATMTECH.BaseModule
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
            EnregistrerParAssembly("ATMTECH.Web.Services");
            EnregistrerParAssembly("ATMTECH.DAO");
            EnregistrerParAssembly("ATMTECH.Services");
        }

        public Assembly VerificationEtForcerloadAssembly()
        {
            string assemblyName = (GetType().Assembly.GetName().Name).Replace(".Services", "") + ".DAO";
            return
                AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == assemblyName) ??
                ChercherAssemblyReferencer(assemblyName);
        }

        public Assembly VerificationEtForcerloadAssembly(string assembly)
        {
            string assemblyName = (GetType().Assembly.GetName().Name).Replace(".Services", "") + ".DAO";
            return
                AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == assemblyName) ??
                ChercherAssemblyReferencer(assemblyName);
        }

        public void EnregistrerParAssembly(string nomAssembly)
        {

            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == nomAssembly) ?? ChercherAssemblyReferencer(nomAssembly);

            if (assembly == null)
            {
                assembly = Assembly.Load(nomAssembly);
            }
            if (nomAssembly.IndexOf("DAO") > 0)
            {

                if (assembly != null)
                {
                    Container.RegisterAssemblyTypes(assembly).Where(t => t.Name.Contains("DAO"))
                       .AsImplementedInterfaces()
                       .PropertiesAutowired();
                }
            }
            else
            {
                Container.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .PropertiesAutowired()
                    .SingleInstance();
            }
        }


        public Assembly ChercherAssemblyReferencer(string assemblyName)
        {
            AssemblyName assemblyReferencer =
                GetType().Assembly.GetReferencedAssemblies().FirstOrDefault(a => a.Name == assemblyName);

            return assemblyReferencer != null ? Assembly.Load(assemblyReferencer) : null;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            Container = builder;
            InitializeFramework();
            InitDependency();
            InitService();
            InitDao();
        }

    }


}

