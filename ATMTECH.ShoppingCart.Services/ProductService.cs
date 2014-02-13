using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.Web.Services.Base;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Services
{
    public class ProductService : BaseService, IProductService
    {
        public IMessageService MessageService { get; set; }
        public IDAOProduct DAOProduct { get; set; }
        public IDAOProductCategory DAOProductCategory { get; set; }
        public IDAOProductPriceHistory DAOProductPriceHistory { get; set; }
        public IMailService MailService { get; set; }
        public IParameterService ParameterService { get; set; }
        public IDAOProductFile DAOProductFile { get; set; }

        public void UpdateProductPriceHistory(Product product, decimal priceBefore, decimal priceAfter)
        {
            DAOProductPriceHistory.UpdateProductPriceHistory(product, priceBefore, priceAfter);
        }
        public bool GetProductAccessOrderable(Product product, int idUser)
        {
            return DAOProduct.GetProductAccessOrderable(product, idUser);
        }
        public Product GetProduct(int id)
        {
            Product product = DAOProduct.GetProduct(id);
            if (product == null)
            {
                MessageService.ThrowMessage(ErrorCode.ErrorCode.SC_THIS_PRODUCT_NUMBER_DONT_EXIST);
            }
            else
            {
                if (product.Stocks.Count == 0)
                {
                    MailService.SendEmail(ParameterService.GetValue(Constant.ADMIN_MAIL), ParameterService.GetValue(Constant.ADMIN_MAIL),
                                     string.Format("Produit sans inventaire: {0}-{1}-{2}", product.Ident, product.Name, product.Enterprise.Name),
                                     string.Format(ParameterService.GetValue(Constant.NO_STOCK_AVAILABLE), product.Ident, product.Name, product.Enterprise.Name));
                }
            }

            return product;
        }
        public IList<Product> GetProductsWithoutLanguage(int idEnterprise)
        {
            return idEnterprise != 0 ? DAOProduct.GetProductsWithoutLanguage(idEnterprise) : null;
        }
        public IList<Product> GetProducts(int idEnterprise)
        {
            return idEnterprise != 0 ? DAOProduct.GetProducts(idEnterprise) : null;
        }
        public IList<Product> GetProductsWithoutStock(int idEnterprise)
        {
            IList<Product> products = DAOProduct.GetProducts(idEnterprise);
            products = products.Where(x => x.Stocks.Count == 0).ToList();
            return products;
        }
        public IList<Product> GetProducts(int idEnterprise, int idUser, string search)
        {
            return idEnterprise != 0 ? DAOProduct.GetProducts(idEnterprise, idUser, search) : null;
        }
        public IList<Product> GetProducts(int idEnterprise, int idProductCategory, int idUser)
        {
            return idEnterprise != 0 ? DAOProduct.GetProducts(idEnterprise, idProductCategory, idUser) : null;
        }
        public IList<Product> GetProducts(int idEnterprise, int idProductCategory)
        {
            return idEnterprise != 0 ? DAOProduct.GetProducts(idEnterprise, idProductCategory) : null;
        }
        public IList<ProductCategory> GetProductCategory(int idEnterprise)
        {
            return DAOProductCategory.GetProductCategoryFromEnterprise(idEnterprise);
        }
        public IList<ProductCategory> GetProductCategoryWithoutLanguage(int idEnterprise)
        {
            return DAOProductCategory.GetProductCategoryFromEnterpriseWithoutLanguage(idEnterprise);
        }
        public IList<ProductFile> GetProductFile(int idEnterprise)
        {
            IList<Product> products = DAOProduct.GetProducts(idEnterprise);

            return DAOProductFile.GetProductFile().Where(productFile => products.Count(x => x.Enterprise.Id == idEnterprise && x.Id == productFile.Product.Id) > 0).ToList();
        }
        public Product GetProductSimple(int id)
        {
            return DAOProduct.GetProductSimple(id);
        }
        public int GetProductCount(int idEnterprise)
        {
            return DAOProduct.GetProductCount(idEnterprise);
        }

        public void SaveProductFile(ProductFile productFile)
        {
            DAOProductFile.SaveProductFile(productFile);
        }
        public int Save(Product product)
        {
            return DAOProduct.SaveProduct(product);
        }
    }
}
