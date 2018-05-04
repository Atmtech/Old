using System;
using System.Web.UI.WebControls;

namespace ATMTECH.GestionMultimedia.Twiggy
{
    public partial class Admin : System.Web.UI.Page
    {

        public string MotPasse
        {
            get
            {
                if (Session["MotPasse"] == null)
                {
                    Session["MotPasse"] = string.Empty;
                }
                return Session["MotPasse"].ToString();
            }
            set
            {
                Session["MotPasse"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(MotPasse))
                {
                    pnlOk.Visible = false;
                    pnlPasOk.Visible = true;
                }
                else

                {
                    pnlOk.Visible = true;
                    pnlPasOk.Visible = false;
                }


                GridViewMovie.DataSource = new DAOGestionMultimediaTwiggy().ObtenirMultimedia();
                GridViewMovie.DataBind();
            }
        }

        protected void btnValiderPasswordClick(object sender, EventArgs e)
        {
            if (txtPassword.Text.ToLower() == "ourson")
            {
                MotPasse = txtPassword.Text;
                pnlOk.Visible = true;
                pnlPasOk.Visible = false;
            }
            else
            {
                pnlOk.Visible = false;
                pnlPasOk.Visible = true;
            }
        }

        protected void GridViewMovieOnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Supprimer")
            {
             
                new DAOGestionMultimediaTwiggy().SupprimerMultimedia(e.CommandArgument.ToString());

                GridViewMovie.DataSource = new DAOGestionMultimediaTwiggy().ObtenirMultimedia();
                GridViewMovie.DataBind();

            }

        }
    }
}