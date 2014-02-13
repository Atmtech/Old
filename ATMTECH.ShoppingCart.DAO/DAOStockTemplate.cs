using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOStockTemplate : BaseDao<StockTemplate, int>, IDAOStockTemplate
    {
        public IList<StockTemplate> GetStockTemplate()
        {
            return GetAllActive();
        }
    }
}
