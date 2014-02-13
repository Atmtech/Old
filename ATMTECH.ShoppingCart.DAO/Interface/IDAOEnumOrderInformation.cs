using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOEnumOrderInformation
    {
        IList<EnumOrderInformation> GetOrderInformation(Enterprise enterprise, string group);
        IList<EnumOrderInformation> GetOrderInformation();
    }
}
