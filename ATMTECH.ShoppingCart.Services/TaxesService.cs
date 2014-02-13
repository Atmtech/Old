using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services
{
    public class TaxesService : BaseService, ITaxesService
    {
        public IDAOTaxes DAOTaxes { get; set; }

        public decimal GetCountryTaxes(decimal total, string type)
        {
            return (DAOTaxes.GetTaxesByType(type).CountryTax * total) / 100;
        }

        public decimal GetRegionTaxes(decimal total, string type)
        {

            return (DAOTaxes.GetTaxesByType(type).RegionalTax * total) / 100;
        }
    }


}
