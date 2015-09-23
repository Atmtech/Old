using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOProduit
    {
        IList<Product> ObtenirListeProduitEnVente(int id);
        Product ObtenirProduit(int id);
        IList<Product> ObtenirProduit(string recherche);
        IList<Product> ObtenirProduitParMarque(string marque);
        IList<Product> ObtenirProduit();
        IList<Product> ObtenirListeProduitEstSlideShow(int id);
        int Save(Product product);
    }
}
