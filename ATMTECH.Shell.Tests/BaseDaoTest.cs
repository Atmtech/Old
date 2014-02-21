using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Web;
using ATMTECH.Web.Session;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Shell.Tests
{
    [TestClass]
    public abstract class BaseDaoTest<TTypeTeste> : IDisposable where TTypeTeste : class
    {

        private MockRepository _mockRepository;
        private ContainerBuilder _containerBuilder;
        private IContainer _container;
        private readonly StateValueInjecteur _stateValueInjecteur = new StateValueInjecteur();
        private TTypeTeste _instanceTest;

        [TestInitialize]
        public void BaseDaoTestInitialize()
        {
            _instanceTest = default(TTypeTeste);
            ConfigurerAutofac();
            InitialiserDependences();



        }

        public TTypeTeste InstanceTest
        {
            get
            {
                return _instanceTest ?? CreerInstanceTest();
            }
        }

        public Fixture AutoFixture
        {
            get
            {
                Fixture fixture = (Fixture)new Fixture().Customize(new MultipleCustomization());
                fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                return fixture;
            }
        }



        public virtual void InitialiserDependences()
        {
        }


        public void CreerDatabaseTest(string nameSpaceEntities)
        {
            InitializeDatabase initializeDatabase = new InitializeDatabase();
            initializeDatabase.InitializeDatabaseSqliteEnMemoire(nameSpaceEntities);
        }


        public void EnregistrerEntite<T>(T entite) where T : BaseEntity
        {
            DatabaseSessionManager.ConnectionString = @"data source=:memory:";
            BaseDao<T, int> daoSave = new BaseDao<T, int>();
            int id = daoSave.Save(entite);
            entite.Id = id;
        }
        public void InsererEntite<T>(T entite) where T : BaseEntity
        {
            DatabaseSessionManager.ConnectionString = @"data source=:memory:";
            BaseDao<T, int> daoSave = new BaseDao<T, int>();
            entite.Id = 0;
            int id = daoSave.Save(entite);
            entite.Id = id;
        }

        private Assembly VerificationEtForcerloadAssembly()
        {
            string assemblyName = (GetType().Assembly.GetName().Name).Replace(".Services", "").Replace(".Tests", "") + ".DAO";
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

        private void ConfigurerAutofac()
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterType<TTypeTeste>().AsSelf();

            //Assembly dataAccess = VerificationEtForcerloadAssembly();

            //if (dataAccess != null)
            //{
            //    _containerBuilder.RegisterAssemblyTypes(dataAccess).Where(t => t.Name.Contains("DAO"))
            //       .AsImplementedInterfaces()
            //       .PropertiesAutowired();
            //}


            ConfiguerAutoMocking();
            ConfigurerStateValue();
            ConfigurerCollectionsGeneriques(_containerBuilder);

            _container = _containerBuilder.Build();
        }
        private void ConfigurerStateValue()
        {
            _containerBuilder.RegisterGeneric(typeof(MockStateValue<>)).As(typeof(IStateValue<>));
        }
        private void ConfiguerAutoMocking()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            _containerBuilder.RegisterInstance(_mockRepository);
            _containerBuilder.RegisterSource(new MoqRegistrationHandler());
        }
        private void ConfigurerCollectionsGeneriques(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(List<>)).As(typeof(ICollection<>));
            containerBuilder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>));
            containerBuilder.RegisterGeneric(typeof(Dictionary<,>)).As(typeof(IDictionary<,>));
            containerBuilder.RegisterGeneric(typeof(HashSet<>)).As(typeof(ISet<>));
        }
        private TTypeTeste CreerInstanceTest()
        {
            _instanceTest = _container.Resolve<TTypeTeste>();
            _stateValueInjecteur.Injecter(_instanceTest, _container);

            _container.InjectUnsetProperties(_instanceTest);


            return _instanceTest;
        }
        public Mock<TMock> ObtenirMock<TMock>() where TMock : class
        {
            return ((IMocked<TMock>)_container.Resolve<TMock>()).Mock;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _container.Dispose();
        }
    }
}
