using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class TaxesBuilder
    {
        public static Taxes Create()
        {
            return new Taxes() { Id = 1 };
        }
        public static Taxes CreateValid()
        {
            return Create().WithCountry(10).WithRegional(10).WithType("QBC");
        }
        public static Taxes WithRegional(this Taxes taxes, int tax)
        {
            taxes.RegionalTax = tax;
            return taxes;
        }

        public static Taxes WithCountry(this Taxes taxes, int tax)
        {
            taxes.CountryTax = tax;
            return taxes;
        }

        public static Taxes WithType(this Taxes taxes, string type)
        {
            taxes.Type = type;
            return taxes;
        }
        public static Taxes WithId(this Taxes taxes, int id)
        {
            taxes.Id = id;
            return taxes;
        }
    }
}
