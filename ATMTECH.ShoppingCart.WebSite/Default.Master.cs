using System;
using System.Web.UI;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class Default : MasterPage, IDefaultMasterPresenter
    {
        public DefaultMasterPresenter Presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presenter.OnViewInitialized();
            }
            Presenter.OnViewLoaded();
        }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get { throw new NotImplementedException(); }
        }

        public void ShowMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            set { string x; }
        }

        public int NumberOfItemInBasket
        {
            set
            {
                if (value == 0)
                {
                    lnkBasket.Enabled = false;
                }
                lblBasketItem.Text = value.ToString();
            }
        }

        public string ImageCorp
        {
            set { string s = value; }
        }

        public int ProductCount
        {
            set { int x = value; }
        }

        public string Welcome
        {
            set { string x = value; }
        }

        public decimal TotalPrice
        {
            set { decimal x = value; }
        }

        public string Language
        {
            set {  }
        }

        public bool IsLogged
        {
            set
            {
                if (value)
                {

                    pnlMenuLogged.Visible = true;
                    pnlMenuUnLogged.Visible = false;
                }
                else
                {
                    pnlMenuLogged.Visible = false;
                    pnlMenuUnLogged.Visible = true;
                }
            }
        }
        protected void RedirectBasket(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.BASKET);
        }
        protected void RedirectProductCatalog(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.PRODUCT_CATALOG);
        }
        protected void RedirectCustomerInformation(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.CUSTOMER_INFORMATION);
        }
        protected void RedirectProductSearch(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.PRODUCT_SEARCH);
        }
    }
}