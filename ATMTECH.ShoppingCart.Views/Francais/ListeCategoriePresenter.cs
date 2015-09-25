using System.Collections.Generic;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Francais;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ListeCategoriePresenter : BaseShoppingCartPresenter<IListeCategoriePresenter>
    {
        public IProduitService ProduitService { get; set; }

        public ListeCategoriePresenter(IListeCategoriePresenter view)
            : base(view)
        {
        }


        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.ListeCategorieAChoisir = ProduitService.ObtenirListeCategorieListeDeroulante();
        }

        public void AfficherProduitPourCategorieChoisi(string categoriesAChercher)
        {
            if (categoriesAChercher != "_")
            {
                IList<CategorieProduit> listeCategorieForce = ProduitService.ObtenirListeCategorieForce();
                View.ListeProduitParCategorie = listeCategorieForce.Count(x => x.Code == categoriesAChercher) > 0 ?
                    ProduitService.ObtenirProduit(categoriesAChercher) :
                    ProduitService.ObtenirProduitParMarque(categoriesAChercher);    
            }
            else
            {
                View.ListeProduitParCategorie = new List<Product>();
            }
            
        }
    }


}