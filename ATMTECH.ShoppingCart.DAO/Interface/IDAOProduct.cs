using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOProduct
    {

        Product GetProduct(int id);
        IList<Product> GetProducts(int idEnterprise, int idUser, string search);
        IList<Product> GetProducts(int idEnterprise, int idProductCategory, int idUser);
        IList<Product> GetProducts(int idEnterprise, int idProductCategory);
        Product GetProductSimple(int id);
        int GetProductCount(int idEnterprise);
        IList<Product> GetProducts(int idEnterprise);
        IList<Product> GetProductsWithoutLanguage(int idEnterprise);
        bool GetProductAccessOrderable(Product product, int idUser);
        IList<Product> GetProductsSimple(int idEnterprise);
        IList<Product> GetProductsWithoutStock(int id);
        IList<Product> GetAllActive();
        int Save(Product product);
        IList<Product> ObtenirListeProduitEnVente(int id);
    }
}
