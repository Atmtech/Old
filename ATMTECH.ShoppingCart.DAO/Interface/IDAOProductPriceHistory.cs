using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOProductPriceHistory
    {
        int UpdateProductPriceHistory(Product product, decimal priceBefore, decimal priceAfter);
        IList<ProductPriceHistory> GetProductPriceHistory(Enterprise enterprise, DateTime dateStart, DateTime dateEnd);
    }
}
