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

        public void AfficherProduitPourCategorieChoisi(string categoriesAChercher)
        {
            View.ListeProduitParCategorie = ProduitService.ObtenirProduit(categoriesAChercher);
        }

    }


}