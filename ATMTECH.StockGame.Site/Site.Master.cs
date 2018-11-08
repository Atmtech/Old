using System;
using System.Collections.Generic;
using System.Web;
using ATMTECH.StockGame.Entites;
using ATMTECH.StockGame.Services;

namespace ATMTECH.StockGame.Site
{
    public partial class Site : System.Web.UI.MasterPage
    {

        public Utilisateur UtilisateurAuthentifie
        {
            get => (Utilisateur)Session["UtilisateurAuthentifie"];
            set => Session["UtilisateurAuthentifie"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EffacerMessage();
            if (UtilisateurAuthentifie != null)
            {
                btnUtilisateurAuthentifie.Text = "Bienvenue, " + UtilisateurAuthentifie.Prenom + " " + UtilisateurAuthentifie.Nom;
                btnUtilisateurAuthentifie.Visible = true;
                btnCreerCompte.Visible = false;
                btnOuvrirUneSession.Visible = false;
                btnFermerSession.Visible = true;
                hyperLinkHome.NavigateUrl = "TableauBord.aspx";

            }
            else
            {
                string url = HttpContext.Current.Request.Url.AbsoluteUri;
                if (!url.Contains("Default.aspx") && !url.Contains("Identification.aspx"))
                    Response.Redirect("Default.aspx");
                hyperLinkHome.NavigateUrl = "Default.aspx";
            }

            RafraichirTitreActif();


        }


        private void RafraichirTitreActif()
        {
            IList<Titre> titres = new TitreService().ObtenirTitreActif();
            repeaterTitreActif.DataSource = titres;
            repeaterTitreActif.DataBind();
        }
        public void AfficherMessage(string message, TypeMessage typeMessage)
        {
            pnlMessageErreur.Visible = false;
            pnlMessageSucces.Visible = false;
            switch (typeMessage)
            {
                case TypeMessage.Erreur:
                    pnlMessageErreur.Visible = true;
                    lblMessageErreur.Text = message;
                    break;
                case TypeMessage.Succes:
                    pnlMessageSucces.Visible = true;
                    lblMessageSucces.Text = message;
                    break;
            }
        }

        public void EffacerMessage()
        {
            pnlMessageErreur.Visible = false;
            pnlMessageSucces.Visible = false;
        }


        protected void btnFermerSessionOnclick(object sender, EventArgs e)
        {
            UtilisateurAuthentifie = null;
            Response.Redirect("Default.aspx");
        }

        protected void btnOuvrirUneSessionOnclick(object sender, EventArgs e)
        {
            Response.Redirect("Identification.aspx");
        }

        protected void btnCreerCompte_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Identification.aspx?Creer=1");
        }

        protected void btnTableauDeBord_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("TableauBord.aspx");
        }

        protected void btnUtilisateurAuthentifie_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Compte.aspx");
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            RafraichirTitreActif();
        }
    }

    public enum TypeMessage
    {
        Erreur = 0,
        Succes = 1
    }

}