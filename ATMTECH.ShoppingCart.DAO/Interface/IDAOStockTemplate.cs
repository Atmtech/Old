using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOStockTemplate
    {
        IList<StockTemplate> GetStockTemplate();
    }
}
