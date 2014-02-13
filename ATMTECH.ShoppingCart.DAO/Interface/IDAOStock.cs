using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOStock
    {
        IList<Stock> GetProductStock(int idProduct);
        Stock GetStock(int idStock);
        void UpdateStock(Stock stock);
        IList<Stock> GetAllStock();
        IList<Stock> GetAllStock(int pageSize, int pageIndex);
        int CreateStock(Stock stock);
        IList<Stock> GetStockByEnterprise(int idEnterprise);
    }
}
