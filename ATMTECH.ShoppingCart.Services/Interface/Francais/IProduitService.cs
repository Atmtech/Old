using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;

namespace ATMTECH.ShoppingCart.Services.Interface.Francais
{
    public interface IProduitService
    {
        Product ObtenirProduit(int id);
        IList<Product> ObtenirProduit();
        IList<Product> ObtenirProduit(string recherche);
        IList<Product> ObtenirProduitParMarque(string marque);
        IList<Product> ObtenirListeProduitEnVente(int id);
        IList<ProductCategory> ObtenirListeCategorie(int id);
        IList<ProductCategory> ObtenirListeCategorie();
        IList<Product> ObtenirListeProduitEstSlideShow(int id);
        IList<CategorieProduit> ObtenirListeCategorieListeDeroulante();
        IList<ProductFile> ObtenirFichierProduit();
        IList<ProductFile> ObtenirFichierProduit(Enterprise enterprise);
        void EnregistrerFichierProduit(ProductFile productFile);
        int Enregistrer(Product product);
        IList<CategorieProduit> ObtenirListeMarque();
        IList<CategorieProduit> ObtenirListeCategorieForce();
    }
}
