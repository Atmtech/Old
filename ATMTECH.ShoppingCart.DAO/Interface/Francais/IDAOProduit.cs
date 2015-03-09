using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOProduit
    {
        IList<Product> ObtenirListeProduitEnVente(int id);
        Product ObtenirProduit(int id);
    }
}
