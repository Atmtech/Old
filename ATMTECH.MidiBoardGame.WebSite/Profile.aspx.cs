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
    public partial class Profile : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                datalistListeJeuBoardGameGeek.DataSource = new DAOJeu().ObtenirListeJeuBoardGameGeek(Utilisateur);
                datalistListeJeuBoardGameGeek.DataBind();
                if (Session["Utilisateur"] != null)
                {
                    txtNom.Text = Utilisateur.Nom;
                    txtCourriel.Text = Utilisateur.Courriel;
                    txtNickNameBoardGameGeek.Text = Utilisateur.BoardGameGeekNickName;
                }
                else
                {
                    Response.Redirect("Identification.aspx");
                }
            }
           

        }

        protected void btnEnregistrerClick(object sender, EventArgs e)
        {
            Utilisateur.Nom = txtNom.Text;
            Utilisateur.BoardGameGeekNickName = txtNickNameBoardGameGeek.Text;
            new DAOUtilisateur().Enregistrer(Utilisateur);
            Response.Redirect("Profile.aspx");
        }

        protected void datalistListeJeuBoardGameGeekItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Ajouter")
            {
                new DAOJeu().Ajouter(e.CommandArgument.ToString(), "1", Utilisateur);
                datalistListeJeuBoardGameGeek.DataSource = new DAOJeu().ObtenirListeJeuBoardGameGeek(Utilisateur);
                datalistListeJeuBoardGameGeek.DataBind();
            }
            if (e.CommandName == "Retirer")
            {
                new DAOJeu().Retirer(e.CommandArgument.ToString(), Utilisateur);
                datalistListeJeuBoardGameGeek.DataSource = new DAOJeu().ObtenirListeJeuBoardGameGeek(Utilisateur);
                datalistListeJeuBoardGameGeek.DataBind();
            }

        }


        protected void btnRevenirAccueilClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}