using System;
using System.Web.UI;
using ATMTECH.Pass.DAO;
using ATMTECH.Pass.Entites;

namespace ATMTECH.Pass.WebSite
{
    public partial class Identification : Page
    {
        public Utilisateur Utilisateur
        {
            get
            {
                return (Utilisateur)Session["Utilisateur"];
            }
            set { Session["Utilisateur"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnecteClick(object sender, EventArgs e)
        {
            if (new DAOUtilisateur().EstIdentifie(txtCourriel.Text, txtMotPasse.Text))
            {
                Utilisateur = new DAOUtilisateur().ObtenirUtilisateur(txtCourriel.Text, txtMotPasse.Text);
                Response.Redirect("Default.aspx");
            }
        }

    }
}