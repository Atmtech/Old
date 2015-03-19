using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views.Francais;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class AddProductToBasket :
        PageBase<AjouterProduitAuPanierPresenter, IAjouterProduitAuPanierPresenter>, IAjouterProduitAuPanierPresenter
    {
        public int IdProduit
        {
            get { return Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.PRODUCT_ID)); }
        }

        public Product Produit
        {
            get { return (Product)Session["ProduitCourant"]; }
            set
            {

                switch (Presenter.CurrentLanguage)
                {

                    case LocalizationLanguage.FRENCH:
                        lblDescription.Text = value.DescriptionFrench;
                        lblNomProduit.Text = value.NameFrench;
                        FillDropDown(ddlStock, value.Stocks, Stock.FEATURE_FRENCH);
                        break;
                    case LocalizationLanguage.ENGLISH:
                        lblDescription.Text = value.DescriptionEnglish;
                        lblNomProduit.Text = value.NameEnglish;
                        FillDropDown(ddlStock, value.Stocks, Stock.FEATURE_ENGLISH);
                        break;
                }

                lblIdentProduit.Text = value.Ident;

                lblPrixEpargner.Text = value.SavePrice.ToString("C");
                lblPrixOriginal.Text = value.UnitPrice.ToString("C");
                if (value.SavePrice > 0)
                {
                    lblPrixEpargner.Visible = true;
                    lblVousEpargnez.Visible = true;
                    lblPrixOriginal.Visible = true;
                    lblPrixUnitaire.Text = value.SalePrice.ToString("C");
                }
                else
                {
                    lblPrixEpargner.Visible = false;
                    lblVousEpargnez.Visible = false;
                    lblPrixOriginal.Visible = false;
                    lblPrixUnitaire.Text = value.UnitPrice.ToString("C");
                }
                imgProductPrincipal.ImageUrl = value.PrincipalFileUrl;

                DataListProductFile.DataSource = value.ProductFiles;
                DataListProductFile.DataBind();
            }
        }

        public int Inventaire
        {
            get { return Convert.ToInt32(ddlStock.SelectedValue); }
            set { ddlStock.SelectedValue = value.ToString(); }
        }

        public int Quantite
        {
            get { return Convert.ToInt32(txtQuantite.Text); }
            set { txtQuantite.Text = value.ToString(); }
        }

        public bool EstPossibleDeCommander
        {
            get { return btnAjouterLigneCommande.Visible; }
            set
            {
                btnVousDevezEtreConnectePourAjouterQuantite.Visible = value == false;
                btnAjouterLigneCommande.Visible = value;
                txtQuantite.Visible = value;
            }
        }

        protected void imgProductPrincipalClick(object sender, ImageClickEventArgs e)
        {
            // throw new NotImplementedException();
        }

        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            //throw new NotImplementedException();
        }

        protected void btnAjouterLigneCommandeClick(object sender, EventArgs e)
        {
            Presenter.AjouterLigneCommande();
        }

        protected void btnVousDevezEtreConnectePourAjouterQuantiteClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.LOGIN);
        }
    }
}