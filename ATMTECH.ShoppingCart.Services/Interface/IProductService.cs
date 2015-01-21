using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IProductService
    {
        Product GetProduct(int id);
        IList<Product> GetProducts(int idEnterprise, int idUser, string search);
        IList<Product> GetProducts(int idEnterprise, int idProductCategory, int idUser);
        IList<Product> GetProducts(int idEnterprise, int idProductCategory);
        IList<ProductCategory> GetProductCategory(int idEnterprise);
        Product GetProductSimple(int id);
        int GetProductCount(int idEnterprise);
        IList<Product> GetProducts(int idEnterprise);
        IList<ProductCategory> GetProductCategoryWithoutLanguage(int idEnterprise);
        IList<ProductFile> GetProductFile(int idEnterprise);
        IList<Product> GetProductsWithoutStock(int idEnterprise);
        IList<Product> GetProductsWithoutLanguage(int idEnterprise);
        void UpdateProductPriceHistory(Product product, decimal priceBefore, decimal priceAfter);
        bool GetProductAccessOrderable(Product product, int idUser);
        void SaveProductFile(ProductFile productFile);
        int Save(Product product);
        IList<Product> GetProductsSimple(int idEnterprise);
        void DeleteProductFile(ProductFile productFile);
        IList<ProductFile> GetProductFile(File file);
        IList<Product> GetAllActive();
    }
}
