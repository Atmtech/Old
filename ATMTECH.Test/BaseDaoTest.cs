using System;
using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.Shell.Tests;
using ATMTECH.Web;
using ATMTECH.Web.Session;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Test
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
