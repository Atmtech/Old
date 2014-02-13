using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Core;

namespace ATMTECH.Web
{
    internal class LooselyTypedParameter : ConstantParameter
    {
        public LooselyTypedParameter(Type type, object value)
            : base(value, pi => pi.ParameterType.IsAssignableFrom(type))
        {
            if (type == null) throw new ArgumentNullException("type");
        }
    }
}
