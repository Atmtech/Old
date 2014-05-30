using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOStockTransaction
    {
        void StockTransaction(Stock stock, int quantity, Order order);
        int GetCurrentStockStatus(Stock stock);
        IList<StockTransaction> GetStockTransactions();
        int GetCurrentStockStatus(Stock stock, DateTime dateStart, DateTime dateEnd);
        IList<StockTransaction> GetAllStockTransaction();
        void StockTransaction(Stock stock, int quantity, Order order, DateTime dateCreated);

    }
}
