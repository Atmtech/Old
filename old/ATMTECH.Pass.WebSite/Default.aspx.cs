using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using ATMTECH.Pass.DAO;
using ATMTECH.Pass.Entites;

namespace ATMTECH.Pass.WebSite
{
    public partial class Default : Page
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
            if (Session["Utilisateur"] != null)
            {
                lblNomUtilisateur.Text = Utilisateur.Nom;
            }
            else
            {
                Response.Redirect("Identification.aspx");
            }

            if (!Page.IsPostBack)
            {

                datalistePass.DataSource = new DAOPass().ObtenirPass(Utilisateur.Id);
                datalistePass.DataBind();
            }


        }
        protected void btnDeconnecteClick(object sender, EventArgs e)
        {
            Utilisateur = null;
            Response.Redirect("Identification.aspx");
        }
    }
}