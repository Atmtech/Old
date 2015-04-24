using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ProductCatalog : PageBase<CatalogueProduitPresenter, ICatalogueProduitPresenter>,
                                          ICatalogueProduitPresenter
    {
        public IList<Product> Produits
        {
            set
            {
                ListeProduit1.Produits = value;
            }
        }
        public string Recherche
        {
            get { return QueryString.GetQueryStringValue(PagesId.SEARCH); }
        }

        public string Marque
        {
            get { return QueryString.GetQueryStringValue(PagesId.BRAND); }
        }

        public string Tri
        {
            get { return QueryString.GetQueryStringValue(PagesId.ORDER_BY_PRICE); }
        }
        public string ImageMarque
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    imgLogoMarque.ImageUrl = value;
                    pnlMarque.Visible = true;
                }
                else
                {
                    pnlMarque.Visible = false;
                }
            }
        }

        public int NombreElementRetrouve
        {
            get { return Convert.ToInt32(lblNombreElement.Text); }
            set { lblNombreElement.Text = value.ToString(); }
        }

        protected void btnTrierMoinsChereAuPlusChereClick(object sender, EventArgs e)
        {
            Presenter.TrierMoinsChereAuPlusChere();
        }

        protected void btnTrierDuPlusChereAuMoinsChereClick(object sender, EventArgs e)
        {
            Presenter.TrierDuPlusChereAuMoinsChere();
        }
    }
}