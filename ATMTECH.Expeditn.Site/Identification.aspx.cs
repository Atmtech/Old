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
            Utilisateur utilisateur = UtilisateurService.ObtenirUtilisateur(txtCourriel.Text, txtMotPasse.Text);
            if (utilisateur != null)
            {
                PageMaitre.UtilisateurAuthentifie = utilisateur;
                Response.Redirect("TableauBord.aspx");
            }
            else
            {
                PageMaitre.AfficherMessage(
                    "L'adresse courriel saisie n'est pas valide ou votre mot de passe est invalide",
                    TypeMessage.Erreur);
            }
        }


        protected void btnCreerCompte_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Identification.aspx?Creer=1");
        }
    }
}