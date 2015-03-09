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
                        lblNom.Text = value.NameFrench;
                        FillDropDown(ddlStock, value.Stocks, Stock.FEATURE_FRENCH);
                        break;
                    case LocalizationLanguage.ENGLISH:
                        lblDescription.Text = value.DescriptionEnglish;
                        lblNom.Text = value.NameEnglish;
                        FillDropDown(ddlStock, value.Stocks, Stock.FEATURE_ENGLISH);
                        break;
                }

                lblIdent.Text = value.Ident;
                lblPrixUnitaire.Text = value.UnitPrice.ToString("C");
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
                btnAjouterLigneCommande.Visible = value;
                txtQuantite.Visible = value;
            }
        }

        protected void imgProductPrincipalClick(object sender, ImageClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ProductFileDataBound(object sender, DataListItemEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ProductFileCommand(object source, DataListCommandEventArgs e)
        {
            throw new NotImplementedException();
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