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
        public string Sujet
        {
            get { return txtSujet.Text; }
            set { txtSujet.Text = value; }
        }
        public string Corps
        {
            get { return txtCorps.Text; }
            set { txtCorps.Text = value; }
        }

        public string Pourcentage
        {
            get { return txtPourcentage.Text; }
            set { txtPourcentage.Text = value; }
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
                    break;
                case "AjusterCommande":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = true;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    break;
                case "RestaureCopie":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = true;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    break;
                case "EditionCourriel":
                    pnlEditionCourriel.Visible = true;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = false;
                    break;
                case "AppliquerPourcentage":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = true;
                    pnlVerifierInventaire.Visible = false;
                    break;
                case "VerifierInventaire":
                    pnlEditionCourriel.Visible = false;
                    pnlAjusterCommande.Visible = false;
                    pnlConfirmerCommande.Visible = false;
                    pnlRestaureCopie.Visible = false;
                    pnlAppliquerPourcentage.Visible = false;
                    pnlVerifierInventaire.Visible = true;
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
            lblApercu.Text = Corps;
        }

        protected void btnAfficherCourrielClick(object sender, EventArgs e)
        {
            Code = ddlListeCourriel.SelectedValue;
            Presenter.AfficherCourriel();
            lblApercu.Text = Corps;
        }

        protected void btnApercuCourrielClick(object sender, EventArgs e)
        {
            lblApercu.Text = Corps;
        }

        protected void btnAppliquerPourcentageClick(object sender, EventArgs e)
        {
            Presenter.AppliquerPourcentage();
        }

        protected void btnVerifierInvenaireClick(object sender, EventArgs e)
        {
            lblNombreEnInventaire.Text = Presenter.VerifierInventaire(txtIdentProduit.Text, txtTaille.Text,
                txtCouleurAnglais.Text);
        }
    }
}