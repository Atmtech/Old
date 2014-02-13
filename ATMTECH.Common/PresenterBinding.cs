using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace ATMTECH.Common
{
    public class PresenterPropertyDiscoveryStrategy : IPresenterDiscoveryStrategy
    {
        public IEnumerable<PresenterDiscoveryResult> GetBindings(IEnumerable<object> hosts, IEnumerable<IView> viewInstances)
        {
            IList<IView> viewInstancesList = viewInstances.ToList();
            foreach (IView view in viewInstancesList)
            {
                IView viewCourant = view;
                Type viewType = viewCourant.GetType();
                PropertyInfo presenterProp = viewType.GetProperty("Presenter");
                if (presenterProp != null)
                {
                    IList<IView> views = new List<IView>();
                    views.Add(view);
                    PresenterBinding binding = new PresenterBinding(presenterProp.PropertyType,
                                                                    viewType,
                                                                    BindingMode.Default, views);
                    IList<PresenterBinding> bindings = new List<PresenterBinding>();
                    bindings.Add(binding);
                    yield return new PresenterDiscoveryResult(views, String.Empty, bindings);
                }
            }
        }
    }
}