using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Moq;

namespace ATMTECH.Web
{
    public class MoqRegistrationHandler : IRegistrationSource
    {

        private readonly MethodInfo _createMethod;
        [SecurityCritical]
        public MoqRegistrationHandler()
        {
            var factoryType = typeof(MockRepository);
            _createMethod = factoryType.GetMethod("Create", new Type[] { });
        }

        [SecuritySafeCritical]
        private object CreateMock(IComponentContext context, TypedService typedService)
        {
            var specificCreateMethod =
                        _createMethod.MakeGenericMethod(new[] { typedService.ServiceType });
            var mock = (Mock)specificCreateMethod.Invoke(context.Resolve<MockRepository>(), null);
            return mock.Object;
        }



        public bool IsAdapterForIndividualComponents
        {
            get { return false; }
        }

        [SecuritySafeCritical]
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            if (service == null)
                throw new ArgumentNullException("service");
            var typedService = service as TypedService;
            if (typedService == null ||
                !typedService.ServiceType.IsInterface ||
                typedService.ServiceType.IsGenericType && typedService.ServiceType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
                typedService.ServiceType.IsArray ||
                typeof(IStartable).IsAssignableFrom(typedService.ServiceType))
                return Enumerable.Empty<IComponentRegistration>();
            var rb = RegistrationBuilder.ForDelegate((c, p) => CreateMock(c, typedService))
                .As(service)
                .InstancePerLifetimeScope();
            return new[] { rb.CreateRegistration() };
        }
    }
}
