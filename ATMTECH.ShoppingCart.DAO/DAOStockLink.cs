using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOStockLink : BaseDao<StockLink, int>, IDAOStockLink
    {
        public IList<StockLink> GetAllStockLinked()
        {
            return GetAllActive();
        }

        public IList<StockLink> GetStockLinked(int idEnterprise)
        {
            string sql =
                "SELECT StockLink.[Id],StockLink.[Description], StockLink.[IsActive] , StockLink.[DateCreated] , StockLink.[DateModified] , StockLink.[Language] , StockLink.[OrderId] , StockLink.[Search] , StockLink.[ComboboxDescription], StockLink.[Stock] , StockLink.[StockLink], StockLink.[UserLoginModified]   FROM StockLink INNER JOIN Stock ON Stock.ID = StockLink.Stock INNER JOIN Product ON PRODUCT.ID = Stock.Product WHERE Product.[Enterprise] =" +
                idEnterprise;

            return GetBySql(sql);
        }
    }
}
