using System;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        public string NomClient
        {
            get { return btnNomClient.Text; }
            set { btnNomClient.Text = value; }
        }

        public bool EstConnecte
        {
            set
            {
                if (value)
                {
                    pnlConnecte.Visible = true;
                    pnlDeconnecte.Visible = false;
                }
                else
                {
                    pnlConnecte.Visible = false;
                    pnlDeconnecte.Visible = true;
                }
            }
        }

        public decimal GrandTotalPanier { set; private get; }
        public decimal NombreTotalItemPanier { set; private get; }
        public bool ThrowExceptionIfNoPresenterBound { get; private set; }

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
    }
}