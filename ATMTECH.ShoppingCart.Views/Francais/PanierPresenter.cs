using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class PanierPresenter : BaseShoppingCartPresenter<IPanierPresenter>
    {
        public IOrderService OrderService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public PanierPresenter(IPanierPresenter view)
            : base(view)
        {
        }

        public void AfficherPanier()
        {
            Customer customer = CustomerService.AuthenticateCustomer;

            if (customer != null)
            {
                View.Commande = OrderService.GetWishListFromCustomer(customer);
            }
            else
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }

        public void FinaliserCommande()
        {
            View.CommandeFinalise = View.Commande;
            OrderService.FinalizeOrder(View.Commande, null);
        }

        public void RecalculerPanier()
        {
            OrderService.UpdateOrder(View.Commande, null);
            AfficherPanier();
        }

        public void ImprimerCommande()
        {
            OrderService.PrintOrder(View.CommandeFinalise);
        }

        public void ModifierAdresse()
        {
            NavigationService.Redirect(Pages.Pages.CUSTOMER_INFORMATION);
        }
    }
}
