using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOInventaire
    {
        IList<Stock> ObtenirInventaire(Product product);
        IList<Stock> ObtenirInventaire(Enterprise entreprise);
        Stock ObtenirInventaire(int id);
        IList<Stock> GetAllActive();
        int Save(Stock stock);
    }
}
