using System;
using System.Collections.Generic;
using System.Web.UI;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

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

        public string AffichagePanier
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    imgPanier.Visible = false;
                    btnPanier.Visible = false;
                    lblAucunItemDansPanier.Visible = true;
                    btnPanier.Visible = false;
                }
                else
                {
                    imgPanier.Visible = true;
                    btnPanier.Visible = true;
                    lblAucunItemDansPanier.Visible = false;
                    btnPanier.Visible = true;
                }
                btnPanier.Text = value;
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
    }
}