using System;
using System.Collections.Generic;
using System.Linq;
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
                Session["ProduitCourant"] = value;
                IList<string> couleur = new List<string>();
                foreach (Stock stock in value.Stocks.Where(stock => !couleur.Contains(stock.ColorFrench)))
                {
                    couleur.Add(stock.ColorFrench);
                }

                IList<string> color = new List<string>();
                foreach (Stock stock in value.Stocks.Where(stock => !color.Contains(stock.ColorEnglish)))
                {
                    color.Add(stock.ColorEnglish);
                }

                IList<string> taille = new List<string>();
                foreach (Stock stock in value.Stocks.Where(stock => !taille.Contains(stock.Size)))
                {
                    taille.Add(stock.Size);
                }


                switch (Presenter.CurrentLanguage)
                {

                    case LocalizationLanguage.FRENCH:
                        lblDescription.Text = value.DescriptionFrench;
                        lblNomProduit.Text = value.NameFrench;
                        FillDropDown(ddlStock, value.Stocks, Stock.FEATURE_FRENCH);
                        FillDropDownWithoutEntity(ddlCouleur, couleur.OrderBy(x => x.ToLower()));
                        break;
                    case LocalizationLanguage.ENGLISH:
                        lblDescription.Text = value.DescriptionEnglish;
                        lblNomProduit.Text = value.NameEnglish;
                        FillDropDown(ddlStock, value.Stocks, Stock.FEATURE_ENGLISH);
                        FillDropDownWithoutEntity(ddlCouleur, color.OrderBy(x => x.ToLower()));
                        break;
                }

                FillDropDownWithoutEntity(ddlTaille, taille.OrderBy(x => x.ToLower()));
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

                ListeFichier.Fichiers = value.ProductFiles;
                //imgProductPrincipal.ImageUrl = value.PrincipalFileUrl;

                ListeCouleur.Langue = Presenter.CurrentLanguage;
                ListeCouleur.Produit = value;
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

        private Stock TrouverLeStockAvecTailleEtCouleur()
        {
            Stock stock = null;
            switch (Presenter.CurrentLanguage)
            {
                case LocalizationLanguage.FRENCH:
                    stock = Produit.Stocks.FirstOrDefault(x => x.FeatureFrench == ddlTaille.SelectedValue + " - " + ddlCouleur.SelectedValue);
                    break;
                case LocalizationLanguage.ENGLISH:
                    stock = Produit.Stocks.FirstOrDefault(x => x.FeatureEnglish == ddlTaille.SelectedValue + " - " + ddlCouleur.SelectedValue);
                    break;
            }
            if (stock == null) return null;
            return stock;
        }
        protected void btnAjouterLigneCommandeClick(object sender, EventArgs e)
        {
            Stock stock = TrouverLeStockAvecTailleEtCouleur();
            if (stock != null)
            {
                Presenter.AjouterLigneCommande();
            }

        }

        protected void btnVousDevezEtreConnectePourAjouterQuantiteClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.LOGIN);
        }
    }
}