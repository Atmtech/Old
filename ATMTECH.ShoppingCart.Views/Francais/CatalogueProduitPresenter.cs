using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class CatalogueProduitPresenter : BaseShoppingCartPresenter<ICatalogueProduitPresenter>
    {
        public CatalogueProduitPresenter(ICatalogueProduitPresenter view)
            : base(view)
        {
        }

        public IProduitService ProduitService { get; set; }
        public IClientService ClientService { get; set; }

        public void AfficherListeProduit()
        {
            View.Produits = !string.IsNullOrEmpty(View.Recherche)
                                ? ProduitService.ObtenirProduit(View.Recherche)
                                : ProduitService.ObtenirProduit();
        }
    }
}