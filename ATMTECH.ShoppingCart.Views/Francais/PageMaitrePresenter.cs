using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
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
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }

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
            Customer customer = CustomerService.AuthenticateCustomer;
            if (customer == null) return;
            View.EstConnecte = true;
            View.NomClient = customer.User.FirstNameLastName;
            decimal grandTotal = OrderService.GetGrandTotalFromOrderWishList(CustomerService.AuthenticateCustomer);
            View.GrandTotalPanier = grandTotal;
            View.NombreTotalItemPanier = grandTotal == 0
                                             ? 0
                                             : OrderService.GetCountNumberOfItemInBasket(
                                                 CustomerService.AuthenticateCustomer);
        }

        public void FermerSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }
    }
}