using System;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class AccueilPresenter : BaseShoppingCartPresenter<IAccueilPresenter>
    {
        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }


        public IProduitService ProduitService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeProduitEnVente();
        }

        public void AfficherListeProduitEnVente()
        {
            View.ListeProduitEnVente = ProduitService.ObtenirListeProduitEnVente(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
        }

        public void AfficherListeCategorie()
        {
            View.ListeCategorie = ProduitService.ObtenirListeCategorie(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
        }
    }
}