using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        protected void btnConnecterClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.LOGIN);
        }
        protected void btnContacterNousClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.CONTACT);
        }
        protected void btnDeconnecterClick(object sender, EventArgs e)
        {
            Presenter.FermerSession();
        }
        protected void btnNomClientClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.CUSTOMER_INFORMATION);
        }
        public bool ThrowExceptionIfNoPresenterBound { get; private set; }

    }
}