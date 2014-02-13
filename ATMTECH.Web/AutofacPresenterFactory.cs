using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting;
using Autofac;
using Microsoft.Practices.Unity.InterceptionExtension;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace ATMTECH.Web
{
    public class AutofacPresenterFactory : IPresenterFactory
    {
        private readonly IContainer _container;
        private readonly IDictionary<object, ILifetimeScope> _presentersToLifetimeScopes = new Dictionary<object, ILifetimeScope>();
        private readonly object _presentersToLifetimeScopesSyncLock = new object();

        public AutofacPresenterFactory(IContainer container)
        {
            _container = container;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            ILifetimeScope scopePresenter = ObtenirLifetimeScopePresenter(presenterType, viewType, viewInstance);
            IPresenter presenter = CreerInstancePresenter(presenterType, viewType, viewInstance, scopePresenter);
            IPresenter presenterIntercepte = ConfigurerInterceptionExceptions(presenter);
            //_stateValueInjecteur.Injecter(presenter, _container);
            ReferencerPresenterDansVue(viewInstance, presenterIntercepte);
            SuivreLifetimeScopePourPresenter(scopePresenter, presenter);
            return presenterIntercepte;
        }

        public void Release(IPresenter presenterIntercepte)
        {
            IPresenter presenter = ObtenirInstancePresenterIntercepte(presenterIntercepte);
            LibererLifetimeScopePourPresenter(presenter);
        }

        private static IPresenter ObtenirInstancePresenterIntercepte(IPresenter presenterIntercepte)
        {
            InterceptingRealProxy realProxy = (InterceptingRealProxy)RemotingServices.GetRealProxy(presenterIntercepte);
            IPresenter presenter = (IPresenter)realProxy.Target;
            return presenter;
        }
        private void SuivreLifetimeScopePourPresenter(ILifetimeScope presenterScope, IPresenter presenter)
        {
            lock (_presentersToLifetimeScopesSyncLock)
            {
                _presentersToLifetimeScopes[presenter] = presenterScope;
            }
        }
        private static void ReferencerPresenterDansVue(IView viewInstance, IPresenter presenterProxy)
        {
            PropertyInfo presenterProperty = viewInstance.GetType().GetProperty("Presenter");
            if (presenterProperty != null)
            {
                presenterProperty.SetValue(viewInstance, presenterProxy,
                                           BindingFlags.Default, null, null, CultureInfo.CurrentUICulture);
            }
        }
        private static IPresenter CreerInstancePresenter(Type presenterType, Type viewType, IView viewInstance,
                                                         IComponentContext presenterScope)
        {
            IPresenter presenter = (IPresenter)presenterScope.Resolve(
                presenterType,
                new LooselyTypedParameter(viewType, viewInstance));
            return presenter;
        }
        private ILifetimeScope ObtenirLifetimeScopePresenter(Type presenterType, Type viewType, IView viewInstance)
        {
            ILifetimeScope presenterScopedContainer = _container.BeginLifetimeScope(
                builder =>
                {
                    builder.
                        RegisterType(presenterType).
                        PropertiesAutowired();
                    builder.RegisterInstance((object)viewInstance).As(viewType);
                }
                );
            return presenterScopedContainer;
        }
        private static IPresenter ConfigurerInterceptionExceptions(IPresenter presenter)
        {
            IPresenter presenterProxy = Intercept.ThroughProxy(presenter, new TransparentProxyInterceptor(), new List<IInterceptionBehavior> { new PresenterInterceptorException() });
            return presenterProxy;
        }
        private void LibererLifetimeScopePourPresenter(IPresenter presenter)
        {
            ILifetimeScope presenterScopedContainer = _presentersToLifetimeScopes[presenter];
            lock (_presentersToLifetimeScopesSyncLock)
            {
                _presentersToLifetimeScopes.Remove(presenter);
            }
            presenterScopedContainer.Dispose();
        }
    }


}