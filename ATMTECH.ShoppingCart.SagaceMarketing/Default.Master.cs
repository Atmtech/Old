using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Common.Constant;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.SagaceMarketing
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

        public void RefreshTotal()
        {
            Presenter.OnViewLoaded();
        }

        public bool ThrowExceptionIfNoPresenterBound { get; set; }

        public void ShowMessage(Message message)
        {

        }
        public int NumberOfItemInBasket
        {
            set
            {
                if (value == 0)
                {
                    btnBasketItem.Enabled = false;
                }
                btnBasketItem.Text = value.ToString();
            }
        }

        public string ImageCorp
        {
            set
            {
                imageCorporative.ImageUrl = "Images/Enterprise/" + value;
            }
        }

        public int ProductCount
        {
            set
            {
                if (value == 0)
                {
                    pnlProduct.Visible = false;
                    pnlSignIn.Visible = true;
                    divContent.Visible = false;
                }
            }
        }

        public string Welcome
        {
            set { lblWelcomeMessageHome.Text = value; }
        }

        public decimal TotalPrice
        {
            set
            {
                lblTotalPrice.Text = String.Format("{0:C}", value);
            }
        }

        public string Name
        {
            set { btnAccount.Text = value; }
        }
        public bool IsLogged
        {
            set
            {
                if (value)
                {

                    btnSignIn.Visible = false;
                    btnAccount.Visible = true;
                    lblWelCome.Visible = true;
                    pnlBasket.Visible = true;
                    btnSignOut.Visible = true;
                    btnSignIn.Visible = false;
                    pnlSignIn.Visible = false;
                }
                else
                {
                    btnSignIn.Visible = true;
                    btnAccount.Visible = false;
                    lblWelCome.Visible = false;
                    pnlBasket.Visible = false;
                    btnSignOut.Visible = false;
                }
            }
        }
        protected void RedirectBasket(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.BASKET);
        }
        protected void RedirectProductCatalog(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.PRODUCT_CATALOG);
        }
        protected void RedirectCustomerInformation(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.CUSTOMER_INFORMATION);
        }
        protected void RedirectProductSearch(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                IList<QueryString> queryStrings = new List<QueryString>();
                queryStrings.Add(new QueryString("Search", txtSearch.Text));
                Presenter.Redirect(Pages.PRODUCT_SEARCH, queryStrings);
            }
        }

        protected void OpenSessionClick(object sender, EventArgs e)
        {
            windowLogin.OuvrirFenetre();
        }

        protected void CloseSessionClick(object sender, EventArgs e)
        {
            Presenter.CloseSession();
        }

        protected void RedirectInformationClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.INFORMATIONS);
        }

        protected void RedirectContactClick(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.CONTACT);
        }

        protected void SetLanguageFrenchClick(object sender, EventArgs e)
        {
            Presenter.SetLanguage(LocalizationLanguage.FRENCH);
        }

        protected void SetLanguageEnglishClick(object sender, EventArgs e)
        {
            Presenter.SetLanguage(LocalizationLanguage.ENGLISH);
        }
    }
}