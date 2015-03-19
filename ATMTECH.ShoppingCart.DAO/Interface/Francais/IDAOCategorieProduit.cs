using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOCategorieProduit
    {
        IList<ProductCategory> GetAllActive();
    }
}
