using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOInventaire
    {
        IList<Stock> ObtenirInventaire(Product product);
        Stock ObtenirInventaire(int id);
        IList<Stock> GetAllActive();
    }
}
