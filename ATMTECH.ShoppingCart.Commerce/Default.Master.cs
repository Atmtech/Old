using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Default : PageMaitreBase<PageMaitrePresenter, IPageMaitrePresenter>, IPageMaitrePresenter
    {
        public string NomClient { get { return btnNomClient.Text; } set { btnNomClient.Text = value; } }
        public string CourrielListeDiffusion { get { return txtListeDiffusion.Text; } set { txtListeDiffusion.Text = value; } }
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
        public string AffichagePanier
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    btnPanier.Visible = false;
                    btnAucunItemDansPanier.Visible = true;
                    btnPanier.Visible = false;
                }
                else
                {
                    btnPanier.Visible = true;
                    btnAucunItemDansPanier.Visible = false;
                    btnPanier.Visible = true;
                }
                btnPanier.Text = value;
            }
        }
        public string AffichageLangue
        {
            set
            {
                if (value == LocalizationLanguage.ENGLISH)
                {
                    btnAnglais.Visible = false;
                    btnFrancais.Visible = true;
                    txtRecherche.Attributes.Remove("PlaceHolder");
                    txtRecherche.Attributes.Add("PlaceHolder", "Search...");
                }
                else
                {
                    btnAnglais.Visible = true;
                    btnFrancais.Visible = false;
                    txtRecherche.Attributes.Remove("PlaceHolder");
                    txtRecherche.Attributes.Add("PlaceHolder", "Rechercher...");
                }
            }
        }
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
        protected void btnPanierClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.BASKET);
        }
        protected void imgRechercheClick(object sender, ImageClickEventArgs e)
        {
            IList<QueryString> queryString = new List<QueryString>();
            queryString.Add(new QueryString(PagesId.SEARCH, txtRecherche.Text));
            Presenter.NavigationService.Redirect(Pages.PRODUCT_CATALOG, queryString);
        }
        protected void btnCategorieProduitClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.PRODUCT_CATEGORY);
        }
        protected void btnConditionClick(object sender, EventArgs e)
        {
            IList<QueryString> queryString = new List<QueryString>();
            queryString.Add(new QueryString(PagesId.CONTENT_ID, "0"));
            Presenter.NavigationService.Redirect(Pages.CONTENT, queryString);
        }
        protected void btnRetourClick(object sender, EventArgs e)
        {
            IList<QueryString> queryString = new List<QueryString>();
            queryString.Add(new QueryString(PagesId.CONTENT_ID, "1"));
            Presenter.NavigationService.Redirect(Pages.CONTENT, queryString);
        }
        protected void btnLivraisonClick(object sender, EventArgs e)
        {
            IList<QueryString> queryString = new List<QueryString>();
            queryString.Add(new QueryString(PagesId.CONTENT_ID, "2"));
            Presenter.NavigationService.Redirect(Pages.CONTENT, queryString);
        }
        protected void btnRejoindreListeDiffusionClick(object sender, EventArgs e)
        {
            Presenter.RejoindreListeDiffusion();
        }
        protected void btnFrancaisClick(object sender, EventArgs e)
        {
            Presenter.MettreSiteEnFrancais();
        }
        protected void btnAnglaisClick(object sender, EventArgs e)
        {
            Presenter.MettreSiteEnAnglais();
        }
        protected void btnAccueilClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.DEFAULT);
        }
    }
}