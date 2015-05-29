using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.HtmlControls;
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
                AfficherListeFichier();

                if (!File.Exists(Server.MapPath(@"Images\WebSite\") + value.Brand + ".jpg"))
                {
                    btnConsulterLaCharte.Visible = false;
                }

                AfficherInformationReseauSociaux(value);
                AfficherLogoMarque(value);
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
        public IList<string> ListeDeroulanteCouleurs
        {
            set { FillDropDownWithoutEntity(ddlCouleur, value); }
        }
        public IList<Couleur> ListeCouleurs
        {
            set
            {
                ListeCouleur.Langue = Presenter.CurrentLanguage;
                ListeCouleur.ListeCouleurs = value;
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
        public void AfficherListeFichier()
        {
            ListeFichier.AfficherListeFichier(((Product)Session["ProduitCourant"]).ProductFiles);
        }

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
            Presenter.AfficherListeDesCouleurs();
            AfficherListeFichier();
        }
        protected void ddlCouleurSelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.AfficherTaille();
            Presenter.AfficherPrix();
            Presenter.AfficherListeDesCouleurs();
            AfficherListeFichier();
        }

        protected void btnConsulterLaCharteClick(object sender, EventArgs e)
        {

            Response.Redirect("Charte.aspx?" + PagesId.PRODUCT_ID + "=" + QueryString.GetQueryStringValue(PagesId.PRODUCT_ID) + "&" + PagesId.CHARTE + "=" + Produit.Brand);
        }

        private void AfficherInformationReseauSociaux(Product produit)
        {
            HtmlMeta metaTitre = new HtmlMeta();
            HtmlMeta metaType = new HtmlMeta();
            HtmlMeta metaDescription = new HtmlMeta();

            switch (Presenter.CurrentLanguage)
            {
                case LocalizationLanguage.FRENCH:
                    metaTitre.Attributes.Add("content", string.Format("({0}) - {1}", produit.UnitPrice.ToString("C"), produit.NameFrench));
                    metaDescription.Attributes.Add("content", produit.DescriptionFrench);
                    break;
                case LocalizationLanguage.ENGLISH:
                    metaTitre.Attributes.Add("content", string.Format("({0}) - {1}", produit.UnitPrice.ToString("C"), produit.NameEnglish));
                    metaDescription.Attributes.Add("content", produit.DescriptionEnglish);
                    break;
            }

            metaTitre.Attributes.Add("property", "og:title");
            metaType.Attributes.Add("property", "og:type");
            metaType.Attributes.Add("content", "product");
            metaDescription.Attributes.Add("property", "og:description");

            MetaPlaceHolder.Controls.Add(metaType);
            MetaPlaceHolder.Controls.Add(metaTitre);
            MetaPlaceHolder.Controls.Add(metaDescription);

            Literal literalFacebook = new Literal { Text = "<div class='fb-like' style='color:white;' data-href='http://www.checkleprix.com/AddProductToBasket.aspx?ProductId=" + produit.Id + "' data-layout='standard' data-action='like' data-show-faces='true' data-share='true'></div>" };
            placeHolderFacebook.Controls.Add(literalFacebook);
            Literal literalTwitter = new Literal { Text = "<a href='https://twitter.com/share' class='twitter-share-button' data-url='http://www.checkleprix.com/AddProductToBasket.aspx?ProductId=" + produit.Id + "' data-via='CheckLePrix'>Tweet</a>" };
            placeHolderTwitter.Controls.Add(literalTwitter);
        }

        private void AfficherLogoMarque(Product produit)
        {
            if (!string.IsNullOrEmpty(produit.Brand))
            {
                imgMarque.Visible = true;
                imgMarque.ImageUrl = "~/images/WebSite/Logo" + produit.Brand + ".jpg";
            }
        }
    }


}