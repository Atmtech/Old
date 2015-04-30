using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class MerciCommandePresenter : BaseShoppingCartPresenter<IMerciCommandePresenter>
    {
        public ICommandeService CommandeService { get; set; }
        public IClientService ClientService { get; set; }

        public MerciCommandePresenter(IMerciCommandePresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherCommande();
        }
        public void AfficherCommande()
        {
            Order order = CommandeService.ObtenirCommande(View.IdCommande);
            if (order.Customer.Id != ClientService.ClientAuthentifie.Id)
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
            View.Commande = order;
        }
        public void ImprimerCommande()
        {
            Order commande = CommandeService.ObtenirCommande(View.IdCommande);
            CommandeService.ImprimerCommande(commande);
        }
    }
}