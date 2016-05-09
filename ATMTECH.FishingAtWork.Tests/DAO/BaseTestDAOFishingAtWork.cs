using System;
using System.Collections.Generic;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Web;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.FishingAtWork.Tests.DAO
{
    public class BaseTestDAOFishingAtWork<TTypeTeste> : IDisposable where TTypeTeste : class
    {
        public string ConnectionString { get { return @"Server=.\ENTREPOTENTR;Database=FishingAtWork;Trusted_Connection=True;"; } }

        private MockRepository _mockRepository;
        private ContainerBuilder _containerBuilder;
        private IContainer _container;
        private TTypeTeste _instanceTest;

        
        [TestInitialize]
        public void BaseDaoTestInitialize()
        {
            DatabaseSessionManager.ConnectionString = ConnectionString;
            DatabaseSessionManager.IsUnitTesting = true;
            DatabaseSessionManager.CurrentSqlTransactionUnitTesting = null;

            _instanceTest = default(TTypeTeste);
            ConfigurerAutofac();
        }

        [TestCleanup]
        public void BaseDaoTestTestCleanupe()
        {
            if (DatabaseSessionManager.CurrentSqlTransactionUnitTesting != null)
                DatabaseSessionManager.CurrentSqlTransactionUnitTesting.Rollback();
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


        private void ConfigurerAutofac()
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterType<TTypeTeste>().AsSelf();
            ConfiguerAutoMocking();
            ConfigurerCollectionsGeneriques(_containerBuilder);
            _container = _containerBuilder.Build();
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
