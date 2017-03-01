using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;

namespace ATMTECH.TransfertVideo
{
    public partial class Administration : PageMaster
    {
        public string MotPasse
        {
            get
            {
                if (Session["MotPAsse"] == null)
                {
                    Session["MotPAsse"] = string.Empty;
                }
                return Session["MotPAsse"].ToString();
            }
            set { Session["MotPAsse"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh();
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

            }
        }

        private void Refresh()
        {

            IList<Film> films = new DAOFilm().ObtenirListeFilm().Where(x=>!string.IsNullOrEmpty(x.Fichier)).OrderBy(x => x.Groupe).ToList();
            lblTotal.Text = films.Count.ToString();
            GridViewMovie.DataSource = films;
            GridViewMovie.DataBind();
        }


        protected void GridViewMovieRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "player")
            {
                Session["IdentifiantUnique"] = e.CommandArgument.ToString();
                Response.Redirect("MoviePlayer.aspx");
            }
            if (e.CommandName.ToLower() == "download")
            {
                Response.Redirect("Download.aspx?guid=" + e.CommandArgument);
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
    }
}