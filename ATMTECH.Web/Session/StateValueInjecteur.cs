using System;
using System.Reflection;
using Autofac;

namespace ATMTECH.Web.Session
{
    public class StateValueInjecteur
    {
        public void Injecter(object instance, IContainer container)
        {
            Type type = instance.GetType();

            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                object stateValue = ObtenirInstanceStateValue(fieldInfo, fieldInfo.FieldType, container);
                if (stateValue != null) fieldInfo.SetValue(instance, stateValue);
            }

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                object stateValue = ObtenirInstanceStateValue(propertyInfo, propertyInfo.PropertyType, container);
                if (stateValue != null) propertyInfo.SetValue(instance, stateValue, null);
            }
        }

        private object ObtenirInstanceStateValue(MemberInfo mi, Type memberType, IComponentContext container)
        {
            object stateValue = null;
            if (memberType.IsGenericType &&
                typeof(IStateValue<>).GetGenericTypeDefinition() == memberType.GetGenericTypeDefinition())
            {
                object[] attr = mi.GetCustomAttributes(typeof(StateDependencyAttribute), false);
                if (attr.Length > 0)
                {
                    string clef = ((StateDependencyAttribute)attr[0]).Clef;
                    stateValue = container.Resolve(memberType, new NamedParameter("clef", clef));
                }
            }

            return stateValue;
        }
    }
}
