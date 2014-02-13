using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOProductCategory
    {
        ProductCategory GetProductCategory(int id);
        IList<ProductCategory> GetProductCategoryFromEnterprise(int idEnterprise);
        IList<ProductCategory> GetProductCategoryFromEnterpriseWithoutLanguage(int idEnterprise);
    }
}
