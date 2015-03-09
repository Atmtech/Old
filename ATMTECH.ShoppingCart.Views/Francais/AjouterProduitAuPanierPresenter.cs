using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class AjouterProduitAuPanierPresenter : BaseShoppingCartPresenter<IAjouterProduitAuPanierPresenter>
    {
        public AjouterProduitAuPanierPresenter(IAjouterProduitAuPanierPresenter view)
            : base(view)
        {
        }

        public IProduitService ProduitService { get; set; }
        public IClientService ClientService { get; set; }
        public ICommandeService CommandeService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherProduit(View.IdProduit);
            GererAffichage();
        }

        public void AfficherProduit(int id)
        {
            if (id == 0)
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
            View.Produit = ProduitService.ObtenirProduit(id);
        }

        public void GererAffichage()
        {
            View.EstPossibleDeCommander = ClientService.ClientAuthentifie != null;
        }

        public void AjouterLigneCommande()
        {
            CommandeService.AjouterLigneCommande(View.Inventaire, View.Quantite);
        }

    }
}