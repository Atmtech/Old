using System;
using System.Collections.Generic;
using System.Web;
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
        public string CourrielCommande
        {
            get { return txtCommandeCourriel.Text; }
        }
        public string NumeroCommandePourCourriel
        {
            get { return txtNoCommandeCourriel.Text; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            MasquerTout();

            switch (NomAction)
            {
                case "ConfirmerCommande":
                    pnlConfirmerCommande.Visible = true;
                    break;
                case "AjusterCommande":
                    pnlAjusterCommande.Visible = true;
                    break;
                case "RestaureCopie":
                    pnlRestaureCopie.Visible = true;
                    break;
                case "EditionCourriel":
                    pnlEditionCourriel.Visible = true;
                    break;
                case "AppliquerPourcentage":
                    pnlAppliquerPourcentage.Visible = true;
                    break;
                case "VerifierInventaire":
                    pnlVerifierInventaire.Visible = true;
                    break;
                case "ValiderPaypal":
                    pnlValiderPourPaypal.Visible = true;
                    break;
                case "EnvoiCourriel":
                    pnlEnvoiCourriel.Visible = true;
                    break;
                case "EnvoiCommandeCourriel":
                    pnlEnvoyerCommandeParCourriel.Visible = true;
                    break;
                case "ImporterExcel":
                    pnlImporterExcel.Visible = true;
                    break;
                case "Paypal":
                    pnlPayerPaypal.Visible = true;
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
        protected void btnEnvoyerCommandeCourrielClick(object sender, EventArgs e)
        {
            Presenter.EnvoyerCourrielCommande();
        }


        private void MasquerTout()
        {
            pnlEditionCourriel.Visible = false;
            pnlAjusterCommande.Visible = false;
            pnlConfirmerCommande.Visible = false;
            pnlRestaureCopie.Visible = false;
            pnlAppliquerPourcentage.Visible = false;
            pnlVerifierInventaire.Visible = false;
            pnlValiderPourPaypal.Visible = false;
            pnlEnvoiCourriel.Visible = false;
            pnlEnvoyerCommandeParCourriel.Visible = false;
            pnlImporterExcel.Visible = false;
            pnlPayerPaypal.Visible = false;
            
        }


        protected void btnImporterExcelClick(object sender, EventArgs e)
        {
            try
            {
                HttpFileCollection hfc = Request.Files;
                string files = string.Empty;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile httpPostedFile = hfc[i];
                    if (httpPostedFile.ContentLength > 0)
                    {
                        Presenter.ImporterExcel(httpPostedFile);
                      
                    }
                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
        }

        protected void btnPayerPaypalClick(object sender, EventArgs e)
        {
            Presenter.PayerPaypal();
        }
    }
}