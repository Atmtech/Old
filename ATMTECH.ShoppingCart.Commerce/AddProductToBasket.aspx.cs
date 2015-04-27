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
                ListeFichier.Fichiers = value.ProductFiles;

                //AfficherPanneauCouleur(value);
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

        public string Couleur
        {
            get { return ddlCouleur.SelectedValue; }
            set { ddlCouleur.SelectedValue = value; }
        }
        public string Taille
        {
            get { return ddlTaille.SelectedValue; }
            set { ddlTaille.SelectedValue = value; }
        }
        public IList<string> Couleurs
        {
            set
            {
                FillDropDownWithoutEntity(ddlCouleur, value);
                ListeCouleur.Langue = Presenter.CurrentLanguage;
                ListeCouleur.Produit = Produit;
            }
        }
        public IList<Taille> Tailles
        {
            set { FillDropDownWithoutEntity(ddlTaille, value.OrderBy(x => x.Ordre), "Nom", "Nom"); }
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
        public decimal PrixUnitaireOriginal
        {
            set
            {
                lblPrixOriginal.Text = value.ToString("C");
                if (Produit.SavePrice > 0)
                {
                    lblPrixEpargner.Visible = true;
                    lblVousEpargnez.Visible = true;
                    lblPrixOriginal.Visible = true;
                }
                else
                {
                    lblPrixEpargner.Visible = false;
                    lblVousEpargnez.Visible = false;
                    lblPrixOriginal.Visible = false;
                    lblPrixUnitaire.Text = value.ToString("C");
                }
            }
        }
        public decimal PrixUnitaireEnSolde
        {
            set
            {
                lblPrixEpargner.Text = value.ToString("C");
                if (Produit.SavePrice > 0)
                {
                    lblPrixEpargner.Visible = true;
                    lblVousEpargnez.Visible = true;
                    lblPrixOriginal.Visible = true;
                    lblPrixUnitaire.Text = value.ToString("C");
                }
                else
                {
                    lblPrixEpargner.Visible = false;
                    lblVousEpargnez.Visible = false;
                    lblPrixOriginal.Visible = false;
                }
            }
        }

        //private void AfficherPanneauCouleur(Product produit)
        //{
        //    IList<string> couleur = new List<string>();
        //    foreach (Stock stock in produit.Stocks.Where(stock => !couleur.Contains(stock.ColorFrench)))
        //    {
        //        couleur.Add(stock.ColorFrench);
        //    }

        //    IList<string> color = new List<string>();
        //    foreach (Stock stock in produit.Stocks.Where(stock => !color.Contains(stock.ColorEnglish)))
        //    {
        //        color.Add(stock.ColorEnglish);
        //    }



        //    ListeCouleur.Langue = Presenter.CurrentLanguage;
        //    ListeCouleur.Produit = produit;
        //}

        protected void btnAjouterLigneCommandeClick(object sender, EventArgs e)
        {
            Presenter.AjouterLigneCommande();
        }
        protected void btnVousDevezEtreConnectePourAjouterQuantiteClick(object sender, EventArgs e)
        {
            Presenter.NavigationService.Redirect(Pages.LOGIN);
        }
        protected void ddlTailleSelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.AfficherPrix();
            //AffichageDuPrix(Produit);
            //AfficherPanneauCouleur(Produit);
        }
        protected void ddlCouleurSelectedIndexChanged(object sender, EventArgs e)
        {
          //  Presenter.AffichageDuPrix();
            //AfficherTaille(Produit, Couleur);
            //AfficherPanneauCouleur(Produit);
        }
    }


}