using System;
using System.Collections.Generic;
using ATMTECH.Administration.Views.Francais;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Web;

namespace ATMTECH.Administration.Commerce
{
    public partial class Action : PageBase<ActionPresenter, IActionPresenter>, IActionPresenter
    {
        public string NomAction
        {
            get { return QueryString.GetQueryStringValue("action"); }
        }
        public IList<string> ListeCopieSauvegarde
        {
            set
            {
                ddlListeCopieSauvegarde.DataSource = value;
                ddlListeCopieSauvegarde.DataBind();
            }
        }
        public string FichierSauvegarde
        {
            get { return ddlListeCopieSauvegarde.SelectedValue; }
        }
        public IList<Mail> ListeCourriel
        {
            set
            {
                FillDropDown(ddlListeCourriel, value, Mail.CODE, Mail.CODE);
            }
        }
        public string Code
        {
            get { return txtCode.Text; }
            set { txtCode.Text = value; }
        }
        public string SujetFr
        {
            get { return txtSujetFr.Text; }
            set { txtSujetFr.Text = value; }
        }
        public string CorpsFr
        {
            get { return txtCorpsFr.Text; }
            set { txtCorpsFr.Text = value; }
        }
        public string SujetEn
        {
            get { return txtSujetEn.Text; }
            set { txtSujetEn.Text = value; }
        }
        public string CorpsEn
        {
            get { return txtCorpsEn.Text; }
            set { txtCorpsEn.Text = value; }
        }
        public string Pourcentage
        {
            get { return txtPourcentage.Text; }
            set { txtPourcentage.Text = value; }
        }
        public DateTime DateDepart
        {
            get { return Convert.ToDateTime(txtDateDepart.Text); }
        }
        public DateTime DateFin
        {
            get { return Convert.ToDateTime(txtDateFin.Text); }
        }

        public string Courriel
        {
            get { return txtCourriel.Text; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (NomAction)
            {
                case "ConfirmerCommande":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = true;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "AjusterCommande":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = true;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "RestaureCopie":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = true;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "EditionCourriel":
                    pnlEditionCourriel.Visible = true;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "AppliquerPourcentage":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = true;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "VerifierInventaire":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = true;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "ValiderPaypal":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = true;
                    pnlEnvoiCourriel.Visible = false;
                    break;
                case "EnvoiCourriel":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    pnlValiderPourPaypal.Visible = false;
                    pnlEnvoiCourriel.Visible = true;
                    break;
            }
        }
        protected void btnRestaurerCopieSauvegardeClick(object sender, EventArgs e)
        {
            string retour = Presenter.RestaurerCopieSauvegarde();
            ShowMessage(new Message { Description = retour, MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnConfirmerCommandeClick(object sender, EventArgs e)
        {
            string retour = Presenter.ConfirmerCommande(Convert.ToInt32(txtNoCommandeConfirmer.Text.Replace(" ", "")));
            ShowMessage(retour.IndexOf("erreur") > 0
                ? new Message { Description = retour, MessageType = Message.MESSAGE_TYPE_ERROR }
                : new Message { Description = retour, MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnSauvegarderCourrielClick(object sender, EventArgs e)
        {
            Presenter.SauvegarderCourriel();
            lblApercuCourrielFrancais.Text = CorpsFr;
            lblApercuCourrielAnglais.Text = CorpsEn;
        }
        protected void btnAfficherCourrielClick(object sender, EventArgs e)
        {
            Code = ddlListeCourriel.SelectedValue;
            Presenter.AfficherCourriel();
            lblApercuCourrielFrancais.Text = CorpsFr;
            lblApercuCourrielAnglais.Text = CorpsEn;
        }

        protected void btnAppliquerPourcentageClick(object sender, EventArgs e)
        {
            Presenter.AppliquerPourcentage();
            ShowMessage(new Message { Description = "Pourcentage appliqué", MessageType = Message.MESSAGE_TYPE_SUCCESS });
        }
        protected void btnVerifierInvenaireClick(object sender, EventArgs e)
        {
            lblNombreEnInventaire.Text = Presenter.VerifierInventaire(txtIdentProduit.Text, txtTaille.Text,
                txtCouleurAnglais.Text);
        }
        protected void btnValiderPaypalClick(object sender, EventArgs e)
        {
            lblRetourValidationPaypal.Text = Presenter.ValiderPaypal();

        }

        protected void btnEnvoiCourrielClick(object sender, EventArgs e)
        {
            lblStatutEnvoiCourriel.Text = Presenter.EnvoyerCourriel() == false ? "Échec de l'envoi du courriel" : "Envoi du courriel réussi";
        }

        protected void btnApercuCourrielFrancaisClick(object sender, EventArgs e)
        {
            lblApercuCourrielFrancais.Text = CorpsFr;
        }

        protected void btnApercuCourrielAnglaisClick(object sender, EventArgs e)
        {
            lblApercuCourrielAnglais.Text = CorpsEn;
        }
    }
}