using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class PageMaitrePresenter : BaseShoppingCartPresenter<IPageMaitrePresenter>
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public PageMaitrePresenter(IPageMaitrePresenter view)
            : base(view)
        {
        }

     

        public void FermerSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }


    }
}
