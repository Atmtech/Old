using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOStockLink
    {
        IList<StockLink> GetStockLinked(int idEnterprise);
        IList<StockLink> GetAllStockLinked();
    }
}
