using System;
using ATMTECH.StockGame.Entites;

namespace ATMTECH.StockGame.Site.UserControl
{
    public partial class UtilisateurSaisie : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Affichage();
            }
        }

        public void Affichage()
        {
            txtPassword.Attributes["type"] = "password";

            if (PageMaitre.UtilisateurAuthentifie != null)
            {
                txtNom.Text = PageMaitre.UtilisateurAuthentifie.Nom;
                txtPrenom.Text = PageMaitre.UtilisateurAuthentifie.Prenom;
                txtCourriel.Text = PageMaitre.UtilisateurAuthentifie.Courriel;
                txtPassword.Text = PageMaitre.UtilisateurAuthentifie.MotPasse;
            }
        }


        protected void btnEnregistrer_OnClick(object sender, EventArgs e)
        {
            if (PageMaitre.UtilisateurAuthentifie != null)
            {
                PageMaitre.UtilisateurAuthentifie.Courriel = txtCourriel.Text;
                PageMaitre.UtilisateurAuthentifie.MotPasse = txtPassword.Text;
                PageMaitre.UtilisateurAuthentifie.Nom = txtNom.Text;
                PageMaitre.UtilisateurAuthentifie.Prenom = txtPrenom.Text;
                UtilisateurService.Enregistrer(PageMaitre.UtilisateurAuthentifie);
                NavigationService.RafraichirPage();
            }
            else
            {
                Utilisateur utilisateur = new Utilisateur
                {
                    Courriel = txtCourriel.Text,
                    MotPasse = txtPassword.Text,
                    Nom = txtNom.Text,
                    Prenom = txtPrenom.Text,
                    EstAdministrateur = "0",
                    Solde = 1000
                };
                UtilisateurService.Enregistrer(utilisateur);
                PageMaitre.UtilisateurAuthentifie = utilisateur;
                Response.Redirect("TableauBord.aspx");
            }
        }

    }
}