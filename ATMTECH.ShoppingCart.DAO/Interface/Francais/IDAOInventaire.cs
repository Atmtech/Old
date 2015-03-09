using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOInventaire
    {
        IList<Stock> ObtenirStock(Product product);
    }
}
