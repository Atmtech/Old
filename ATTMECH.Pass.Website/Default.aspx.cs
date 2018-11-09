using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ATMTECH.Pass.Website
{
    public partial class Default : System.Web.UI.Page
    {

        public Utilisateur UtilisateurAuthentifie
        {
            get
            {
                if (Session["Utilisateur"] == null)
                    Session["Utilisateur"] = new Utilisateur();
                return (Utilisateur)Session["Utilisateur"];
            }
            set => Session["Utilisateur"] = value;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Utilisateur"] == null || string.IsNullOrEmpty(((Utilisateur)Session["Utilisateur"]).MotPasse))
            {
                pnlIdentification.Visible = true;
                pnlIdentifie.Visible = false;
            }
            else
            {
                Rafraichir();
            }
        }

        private void Rafraichir()
        {
            List<MotPasse> motPasses = new BaseDAO<MotPasse>().Obtenir().Where(x => x.Utilisateur.Id == UtilisateurAuthentifie.Id).ToList();
            repeaterPassword.DataSource = motPasses;
            repeaterPassword.DataBind();
        }

        protected void btnConnecterOnClick(object sender, EventArgs e)
        {
            Utilisateur utilisateur = new BaseDAO<Utilisateur>().Obtenir().FirstOrDefault(x => x.Courriel == txtCourriel.Text);
            if (utilisateur == null)
            {
                AfficherMessage("Méchant chat", TypeMessage.Erreur);
            }
                else
            {
                if (utilisateur.MotPasse == txtMotPasse.Text)
                {
                    pnlIdentifie.Visible = true;
                    pnlIdentification.Visible = false;
                    UtilisateurAuthentifie = utilisateur;
                    btnFermerSession.Visible = true;
                    EffacerMessage();
                    Rafraichir();
                }
            }
            

        }

        public void EffacerMessage()
        {
            pnlMessageErreur.Visible = false;
            pnlMessageSucces.Visible = false;
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


        protected void btnAjouterMotPasse_OnClick(object sender, EventArgs e)
        {
            MotPasse motPasse = new MotPasse
            {
                Courriel = txtCourrielAjouter.Text,
                Emplacement = txtEmplacementAjouter.Text,
                MotDePasse = txtMotPasseAjouter.Text,
                Utilisateur = UtilisateurAuthentifie
            };
            new BaseDAO<MotPasse>().Enregistrer(motPasse);

            txtCourrielAjouter.Text = string.Empty;
            txtEmplacementAjouter.Text = string.Empty;
            txtMotPasseAjouter.Text = string.Empty;
            Rafraichir();
        }

        protected void btnFermerSessionOnclick(object sender, EventArgs e)
        {
            UtilisateurAuthentifie = null;
            Response.Redirect("Default.aspx");
        }
    }
    public enum TypeMessage
    {
        Erreur = 0,
        Succes = 1
    }

}