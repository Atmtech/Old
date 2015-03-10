using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class PageMaitrePresenter : BaseShoppingCartPresenter<IPageMaitrePresenter>
    {
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

        public IAuthenticationService AuthenticationService { get; set; }
        public IClientService ClientService { get; set; }
        public ICommandeService CommandeService { get; set; }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            EstSiteHorsLigne();
            AfficherInformation();
        }

        public void EstSiteHorsLigne()
        {
            string isOffline = ParameterService.GetValue(Constant.IS_OFFLINE);
            if (string.IsNullOrEmpty(isOffline)) return;
            if (isOffline == "1")
            {
                NavigationService.Redirect(Pages.Pages.MAINTENANCE);
            }
        }

        public void AfficherInformation()
        {
            Customer customer = ClientService.ClientAuthentifie;
            if (customer == null) return;
            View.EstConnecte = true;
            View.NomClient = customer.User.FirstNameLastName;

            Order order = CommandeService.ObtenirCommandeSouhaite(customer);

            if (order == null) return;
            string affichagePanier = string.Format("{0} - {1} item", order.GrandTotal, order.GrandTotal == 0
                                                                                           ? 0

                                                                                            : order.OrderLines.Count);
            View.AffichagePanier = affichagePanier;
        }

        public void FermerSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
    }
}