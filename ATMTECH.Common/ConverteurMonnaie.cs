using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace ATMTECH.Common
{
    public class ConvertisseurMonnaie : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return value.ToString();

            if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo ci = typeof(Monnaie).GetConstructor(new[] { typeof(decimal) });
                decimal valeurDecimale = ((Monnaie)value).ObtenirValeurDecimale();
                return new InstanceDescriptor(ci, new object[] { valeurDecimale });
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valeur)
        {
            if (valeur != null && valeur is string)
            {
                return new Monnaie(decimal.Parse(valeur as string, NumberStyles.Currency));
            }
            
            return base.ConvertFrom(context, culture, valeur);
        }
    }
}
