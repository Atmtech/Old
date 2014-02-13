using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOEnterpriseAddress
    {
        IList<Address> GetBillingAddress(Enterprise enterprise);
        IList<Address> GetShippingAddress(Enterprise enterprise);
    }
}
