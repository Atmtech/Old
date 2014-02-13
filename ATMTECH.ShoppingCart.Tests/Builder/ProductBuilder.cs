using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class ProductBuilder
    {
        public static Product Create()
        {
            return new Product() { Id = 1 };
        }

        public static Product CreateValid()
        {
            return Create().WithName("Test").WithCostPrice(10).WithUnitPrice(10).WithWeight(10).WithEnterprise(EnterpriseBuilder.CreateValid());
        }
        public static Product WithCostPrice(this Product product, decimal costPrice)
        {
            product.CostPrice = costPrice;
            return product;
        }

        public static Product WithUnitPrice(this Product product, decimal unitPrice)
        {
            product.UnitPrice = unitPrice;
            return product;
        }

        public static Product WithDescription(this Product product, string description)
        {
            product.Description = description;
            return product;
        }

        public static Product WithWeight(this Product product, decimal weight)
        {
            product.Weight = weight;
            return product;
        }
        public static Product WithName(this Product product, string name)
        {
            product.Name = name;
            return product;
        }

        public static Product WithIdent(this Product product, string ident)
        {
            product.Ident = ident;
            return product;
        }
        public static Product WithId(this Product product, int id)
        {
            product.Id = id;
            return product;
        }

        public static Product WithEnterprise(this Product product, Enterprise enterprise)
        {
            product.Enterprise = enterprise;
            return product;
        }

        public static Product WithProductCategory(this Product product, ProductCategory productCategory)
        {
            product.ProductCategory = productCategory;
            return product;
        }
        public static Product WithSupplier(this Product product, Supplier supplier)
        {
            product.Supplier = supplier;
            return product;
        }

        public static Product WithLanguage(this Product product, string language)
        {
            product.Language = language;
            return product;
        }

        public static Product WithStock(this Product product, Stock stock)
        {
            if (product.Stocks == null)
            {
                product.Stocks = new List<Stock>();
            }
            product.Stocks.Add(stock);
            return product;
        }

    }
}
