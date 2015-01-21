using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IStockService
    {
        int Save(Stock stock);
        IList<Stock> GetProductStock(int idProduct);
        Stock GetStock(int idStock);
        void StockTransaction(int idStock, int quantity, Order order, StockService.TransactionType transactionType);
        bool ValidateStockQuantity(Stock stock, int quantity);
        int GetCurrentStockStatus(Stock stock);
        int GetCurrentStockStatus(Stock stock, DateTime dateStart, DateTime dateEnd);
        IList<Stock> GetAllStock();
        IList<StockTransaction> GetStockTransaction();
        IList<Stock> GetAllStock(int pageSize, int pageIndex);
        void CreateStockWithTemplate(Product product, string templateGroup, int quantity, bool isWithoutStock);
        IList<StockTemplate> GetStockTemplate();
        IList<Stock> GetAllStockByEnterprise(int idEnterprise);
        IList<StockLink> GetStockLink(int idEnterprise);
        IList<StockTransaction> GetAllStockTransaction();
        int SaveStockTransaction(StockTransaction stockTransaction);
    }
}
