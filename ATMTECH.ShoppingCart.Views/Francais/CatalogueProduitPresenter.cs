using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

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

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeProduit();
            AfficherLogoMarque();
        }
        public void AfficherLogoMarque()
        {
            if (!string.IsNullOrEmpty(View.Marque))
            {
                View.ImageMarque = "/Images/WebSite/Logo" + View.Marque + ".jpg";
            }
            else
            {
                View.ImageMarque = "";
            }
        }
        public void AfficherListeProduit()
        {
            if (!string.IsNullOrEmpty(View.Recherche))
            {
                IList<Product> produits = ProduitService.ObtenirProduit(View.Recherche);
                View.Produits = produits;
            }
            else if (!string.IsNullOrEmpty(View.Marque))
            {
                IList<Product> produits = ProduitService.ObtenirProduitParMarque(View.Marque);
                View.Produits = produits;
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }
    }
}
