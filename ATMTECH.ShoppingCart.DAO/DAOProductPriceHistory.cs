using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOProductPriceHistory : BaseDao<ProductPriceHistory, int>, IDAOProductPriceHistory
    {
        public IDAOProduct DAOProduct { get; set; }
        public int UpdateProductPriceHistory(Product product, decimal priceBefore, decimal priceAfter)
        {
            ProductPriceHistory productPriceHistory = new ProductPriceHistory();
            productPriceHistory.Product = product;
            productPriceHistory.PriceBefore = priceBefore;
            productPriceHistory.PriceAfter = priceAfter;
            productPriceHistory.DateChanged = DateTime.Now;
            return Save(productPriceHistory);
        }

        public IList<ProductPriceHistory> GetProductPriceHistory(Enterprise enterprise, DateTime dateStart, DateTime dateEnd)
        {
            IList<ProductPriceHistory> productPriceHistories = GetAllActive();
            productPriceHistories = productPriceHistories.Where(x => x.DateChanged >= dateStart && x.DateChanged <= dateEnd).ToList();
            foreach (ProductPriceHistory productPriceHistory in productPriceHistories)
            {
                productPriceHistory.Product = DAOProduct.GetProduct(productPriceHistory.Product.Id);
            }
            return productPriceHistories.Where(x=>x.Product.Enterprise.Id == enterprise.Id).ToList();
        }
    }
}
