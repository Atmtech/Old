using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOGroupProduct
    {
        IList<GroupProduct> GetGroupProduct();
        IList<GroupProduct> GetGroupProduct(Group group);
        IList<GroupProduct> GetGroupProduct(Product product);
        GroupProduct GetProductAccess(Product product, int idUser);
    }
}
