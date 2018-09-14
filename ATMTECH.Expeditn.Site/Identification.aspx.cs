using System;
using ATMTECH.Expeditn.Entites;

namespace ATMTECH.Expeditn.Site
{
    public partial class Identification : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Creer"]))
                {
                    pnlIdentification.Visible = false;
                    pnlCreerUtilisateur.Visible = true;
                }
                else
                {
                    pnlIdentification.Visible = true;
                    pnlCreerUtilisateur.Visible = false;
                }
            }
        }


        protected void btnConnecterOnClick(object sender, EventArgs e)
        {
            if (UtilisateurVue.Authentification(txtCourriel.Text, txtMotPasse.Text))
            {
                PageMaitre.UtilisateurAuthentifie =
                    UtilisateurVue.ObtenirUtilisateur(txtCourriel.Text, txtMotPasse.Text);
                Response.Redirect("TableauBord.aspx");
            }
            else
            {
                PageMaitre.AfficherMessage("L'adresse courriel saisie n'est pas valide ou votre mot de passe est invalide", TypeMessage.Erreur);
            }
        }

        protected void btnCreer_OnClick(object sender, EventArgs e)
        {
            Utilisateur utilisateur = new Utilisateur
            {
                Courriel = txtCourrielCreation.Text,
                MotPasse = txtPasswordCreation.Text,
                Nom = txtNom.Text,
                Prenom = txtPrenom.Text,
                EstAdministrateur = "0"
            };
            UtilisateurVue.Enregistrer(utilisateur);
            if (UtilisateurVue.Authentification(utilisateur.Courriel, utilisateur.MotPasse))
            {
                PageMaitre.UtilisateurAuthentifie = UtilisateurVue.ObtenirUtilisateur(utilisateur.Courriel, utilisateur.MotPasse);
                Response.Redirect("TableauBord.aspx");
            }
        }

        protected void btnCreerCompte_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Identification.aspx?Creer=1");
        }
    }
}