using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Common.Constant;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Lauzon
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
                if (value > 0)
                {
                    lblNumberArticle.Visible = true;
                    lblArticle.Visible = true;
                    lblTotalPrice.Visible = true;
                }
                else
                {
                    lblNumberArticle.Visible = false;
                    lblArticle.Visible = false;
                    lblTotalPrice.Visible = false;
                }

                lblNumberArticle.Text = value.ToString();
            }
        }

        public string ImageCorp
        {
            set
            {
                if (System.IO.File.Exists(Server.MapPath("Images/Enterprise/" + value)))
                {
                    imageCorporative.ImageUrl = "Images/Enterprise/" + value;    
                }
                else
                {
                    imageCorporative.Visible = false;
                }
            }
        }

        public int ProductCount
        {
            set
            {
                lblProductCount.Text = value.ToString();
            }
        }

        public string Welcome
        {
            set { /*lblWelcomeMessageHome.Text = value; */}
        }

        public decimal TotalPrice
        {
            set
            {
                lblTotalPrice.Text = String.Format("{0:C}", value);
            }
        }

        public string Language
        {
            set
            {
                SetObjectFromLanguage();
                lnkLanguage.Text = value;
            }
        }

        private void SetObjectFromLanguage()
        {
            if (Presenter.ReturnLanguage() == LocalizationLanguage.FRENCH)
            {
                imgVetement.ImageUrl = "Images/WebSite/VetementsFr.png";
                imgArticlePromotionnel.ImageUrl = "Images/WebSite/ArticlePromoFr.png";
                imgConditionUtilisation.ImageUrl = "Images/WebSite/ConditionUtilisationFr.png";
                imgEtapePourCommander.ImageUrl = "Images/WebSite/EtapePourCommanderFr.png";
                imgServiceClientele.ImageUrl = "Images/WebSite/ServiceClienteleFr.png";
            }
            else
            {
                imgVetement.ImageUrl = "Images/WebSite/VetementsEn.png";
                imgArticlePromotionnel.ImageUrl = "Images/WebSite/ArticlePromoEn.png";
                imgConditionUtilisation.ImageUrl = "Images/WebSite/ConditionUtilisationEn.png";
                imgEtapePourCommander.ImageUrl = "Images/WebSite/EtapePourCommanderEn.png";
                imgServiceClientele.ImageUrl = "Images/WebSite/ServiceClienteleEn.png";
            }   
        }

        public Enterprise Enterprise
        {
            set
            {
                lblEnterprise.Text = value.Name;
                if (value.Id == 1)
                {
                    pnlMenuBottom.Visible = false;
                }

                if (Presenter.CurrentLanguage == "fr")
                {
                    lnkVetement.NavigateUrl = "ProductCatalog.aspx?ProductCategoryId=92";
                    lnkArticlePromotionnel.NavigateUrl = "ProductCatalog.aspx?ProductCategoryId=96";
                }
                else
                {
                    lnkVetement.NavigateUrl = "ProductCatalog.aspx?ProductCategoryId=94";
                    lnkArticlePromotionnel.NavigateUrl = "ProductCatalog.aspx?ProductCategoryId=97";
                }

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
                    btnSignOut.Visible = true;
                    pnlAccount.Visible = true;
                }
                else
                {
                    btnSignIn.Visible = true;
                    btnSignOut.Visible = false;
                    pnlAccount.Visible = false;
                }
            }
        }
        protected void RedirectBasket(object sender, EventArgs e)
        {
            Presenter.Redirect(btnSignOut.Visible ? Pages.BASKET : Pages.LOGIN);
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

        protected void CloseSessionClick(object sender, EventArgs e)
        {
            Presenter.CloseSession();
        }

        protected void RedirectLanguage(object sender, EventArgs e)
        {
            Presenter.SetLanguage();
        }

        protected void RedirectHome(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.DEFAULT);
        }

        protected void OpenSession(object sender, EventArgs e)
        {
            Presenter.Redirect(Pages.LOGIN);
        }
    }
}