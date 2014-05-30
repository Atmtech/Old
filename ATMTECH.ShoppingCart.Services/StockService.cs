using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.ShoppingCart.Services
{
    public class StockService : BaseService, IStockService
    {
        public enum TransactionType
        {
            Add = 0,
            Remove = 1
        }

        public IDAOStock DAOStock { get; set; }
        public IDAOStockTransaction DAOStockTransaction { get; set; }
        public IDAOStockTemplate DAOStockTemplate { get; set; }
        public IDAOStockLink DAOStockLink { get; set; }
        public IProductService ProductService { get; set; }

        public int Save(Stock stock)
        {
            return DAOStock.Save(stock);
        }

        public IList<Stock> GetProductStock(int idProduct)
        {
            return DAOStock.GetProductStock(idProduct);
        }
        public Stock GetStock(int idStock)
        {
            Stock stock = DAOStock.GetStock(idStock);
            stock.Product = ProductService.GetProduct(stock.Product.Id);
            return stock;
        }
        public int GetCurrentStockStatus(Stock stock, DateTime dateStart, DateTime dateEnd)
        {
            return DAOStockTransaction.GetCurrentStockStatus(stock, dateStart, dateEnd);
        }
        public IList<Stock> GetAllStock()
        {
            return DAOStock.GetAllStock();
        }
        public IList<Stock> GetAllStockByEnterprise(int idEnterprise)
        {
            return DAOStock.GetStockByEnterprise(idEnterprise);
        }

        public IList<StockLink> GetStockLink(int idEnterprise)
        {
            return DAOStockLink.GetStockLinked(idEnterprise);
        }
        public IList<Stock> GetAllStock(int pageSize, int pageIndex)
        {
            return DAOStock.GetAllStock(pageSize, pageIndex);
        }
        public void StockTransaction(int idStock, int quantity, Order order, TransactionType transactionType)
        {
            SetStock(idStock, quantity, order, transactionType);
        }
        public IList<StockTransaction> GetStockTransaction()
        {
            return DAOStockTransaction.GetStockTransactions();
        }
        public bool ValidateStockQuantity(Stock stock, int quantity)
        {
            return quantity <= GetCurrentStockStatus(stock);
        }
        public int GetCurrentStockStatus(Stock stock)
        {
            return DAOStockTransaction.GetCurrentStockStatus(stock);
        }
        public void CreateStockWithTemplate(Product product, string templateGroup, int quantity, bool isWithoutStock)
        {
            IList<StockTemplate> stockTemplates = GetStockTemplate();
            stockTemplates = stockTemplates.Where(x => x.Group == templateGroup).ToList();
            foreach (StockTemplate stockTemplate in stockTemplates)
            {

                DAOStock.CreateStock(new Stock
                {
                    AdjustPrice = 0,
                    FeatureFrench = stockTemplate.Description,
                    FeatureEnglish = stockTemplate.Description,
                    Product = product,
                    InitialState = quantity,
                    Language = stockTemplate.Language,
                    IsWithoutStock = isWithoutStock
                });
            }
        }
        public IList<StockTemplate> GetStockTemplate()
        {
            return DAOStockTemplate.GetStockTemplate();
        }
        private IList<Stock> GetStockLinked(int idStock)
        {
            IList<StockLink> stockLinks = DAOStockLink.GetAllStockLinked();

            IList<Stock> stocks = (from stockLink in stockLinks where stockLink.Stock.Id == idStock select new Stock { Id = stockLink.StockLinked.Id }).ToList();
            foreach (StockLink stockLink in stockLinks.Where(stockLink => stockLink.StockLinked != null).Where(stockLink => stockLink.StockLinked.Id == idStock))
            {
                stocks.Add(new Stock { Id = stockLink.Stock.Id });
            }
            return stocks;
        }
        private void SetStock(int idStock, int quantity, Order order, TransactionType transactionType)
        {
            IList<Stock> stocksLink = GetStockLinked(idStock);

            Stock stock = GetStock(idStock);

            stocksLink.Add(stock);

            foreach (Stock stock1 in stocksLink)
            {
                if (stock1.IsWithoutStock) return;
                switch (transactionType)
                {
                    case TransactionType.Add:
                        break;
                    case TransactionType.Remove:
                        quantity = quantity * -1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("transactionType");
                }
                DAOStockTransaction.StockTransaction(stock1, quantity, order);
            }
        }
        public IList<StockTransaction> GetAllStockTransaction()
        {
            return DAOStockTransaction.GetAllStockTransaction();
            
        }
    }
}
