using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class AddProductToBasket : PageBaseShoppingCart<AjouterProduitAuPanierPresenter, IAjouterProduitAuPanierPresenter>, IAjouterProduitAuPanierPresenter
    {
        public int IdProduit { get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.PRODUCT_ID)); } }

        public Product Produit
        {
            get
            {
                return (Product)Session["ProduitCourant"];
            }
            set
            {
                switch (Presenter.CurrentLanguage)
                {
                    case LocalizationLanguage.FRENCH:
                        lblDescription.Text = value.DescriptionFrench;
                        lblNom.Text = value.NameFrench;
                        break;
                    case LocalizationLanguage.ENGLISH:
                        lblDescription.Text = value.DescriptionEnglish;
                        lblNom.Text = value.NameEnglish;
                        break;
                }

                lblPrixUnitaire.Text = value.UnitPrice.ToString("C");
                imgProductPrincipal.ImageUrl = value.PrincipalFileUrl;
            }
        }
        public int Inventaire { get { return Convert.ToInt32(ddlStock.SelectedValue); } set { ddlStock.SelectedValue = value.ToString(); } }
        public int Quantite { get { return Convert.ToInt32(txtQuantite.Text); } set { txtQuantite.Text = value.ToString(); } }

        protected void imgProductPrincipalClick(object sender, ImageClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        protected void btnAjouterLigneCommandeClick(object sender, EventArgs e)
        {
            Presenter.AjouterLigneCommande();
        }
    }
}