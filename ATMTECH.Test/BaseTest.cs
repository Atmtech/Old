using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using ATMTECH.Shell.Tests;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;
using ATMTECH.Web.Session;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace ATMTECH.Test
{
    /// <summary>
    /// Classe de base pour tous les tests unitaires
    /// qui testent une classe qui utilise l'injection
    /// de dépendances.
    /// 
    /// La methode InitialiserDependences doit être
    /// implémentée absolument.
    /// </summary>
    /// <typeparam name="TTypeTeste">Le type à tester</typeparam>
    [TestClass]
    public abstract class BaseTest<TTypeTeste> : IDisposable where TTypeTeste : class
    {
        public Mock<IMessageService> MockMessageService { get { return ObtenirMock<IMessageService>(); } }
        public Mock<IMailService> MockMailService { get { return ObtenirMock<IMailService>(); } }
        public Mock<IParameterService> MockParameterService { get { return ObtenirMock<IParameterService>(); } }
        public Mock<IAuthenticationService> MockAuthenticationService { get { return ObtenirMock<IAuthenticationService>(); } }

        public Fixture AutoFixture
        {
            get
            {
                Fixture fixture = (Fixture) new Fixture().Customize(new MultipleCustomization());
                fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                return fixture;
            }
        }

        private readonly bool _faireResolutionProprietes;
        private MockRepository _mockRepository;
        private ContainerBuilder _containerBuilder;
        private IContainer _container;
        private readonly StateValueInjecteur _stateValueInjecteur = new StateValueInjecteur();
        private TTypeTeste _instanceTest;

        [TestInitialize]
        public void BaseTestInitialize()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");

         
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
        public virtual void InitialiserDependences()
        {
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
        public void VerifyException(string innerId)
        {
            MockMessageService.Verify(test => test.ThrowMessage(It.Is<string>(a => a == innerId)));
        }

        protected BaseTest()
        {
            _faireResolutionProprietes = true;
        }
        protected BaseTest(bool faireResolutionProprietes)
        {
            _faireResolutionProprietes = faireResolutionProprietes;
        }
        protected virtual void Dispose(bool disposing)
        {
            _container.Dispose();
        }

        private void ConfigurerAutofac()
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterType<TTypeTeste>().AsSelf();

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

            if (_faireResolutionProprietes)
                _container.InjectUnsetProperties(_instanceTest);

            return _instanceTest;
        }

    }
}