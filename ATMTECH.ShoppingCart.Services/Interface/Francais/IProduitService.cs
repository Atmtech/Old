using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IProduitService
    {
        Product ObtenirProduit(int id);
        IList<Product> ObtenirProduit();
        IList<Product> ObtenirProduit(string recherche);
        IList<Product> ObtenirListeProduitEnVente(int id);
        IList<ProductCategory> ObtenirListeCategorie(int id);
        IList<Product> ObtenirListeProduitSlideShow(int id);
    }
}
