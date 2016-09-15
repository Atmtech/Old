using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.MidiBoardGame.DAO;
using ATMTECH.MidiBoardGame.Entites;

namespace ATMTECH.MidiBoardGame.WebSite
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

        protected void btnCreerClick(object sender, EventArgs e)
        {
            new DAOUtilisateur().Ajouter(txtNomCreer.Text, txtNickNameBoardGameGeek.Text, txtCourrielCreer.Text, txtMotDePasseCreer.Text);
            Utilisateur = new DAOUtilisateur().ObtenirUtilisateur(txtCourrielCreer.Text, txtMotDePasseCreer.Text);
            Response.Redirect("Default.aspx");
        }

    }
}