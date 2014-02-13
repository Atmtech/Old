using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface ITaxesService
    {
        decimal GetCountryTaxes(decimal total, string type);
        decimal GetRegionTaxes(decimal total, string type);
    }
}
