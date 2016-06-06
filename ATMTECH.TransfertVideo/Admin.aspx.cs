using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;
using ATMTECH.Web;

namespace ATMTECH.TransfertVideo
{
    public partial class Admin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Refresh("all");
            }
        }

        protected void GridViewMovie_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visionnee")
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == e.CommandArgument.ToString());
                film.Visionnee = true;
                new DAOFilm().Save(film);
            }

            if (e.CommandName == "Voir")
            {
                Session["IdentifiantUnique"] = e.CommandArgument.ToString();
                Response.Redirect("Player.aspx");
            }

        }

        private void Refresh(string groupe)
        {
            var films = groupe == "all" ? new DAOFilm().ObtenirListeFilm() : new DAOFilm().ObtenirListeFilm().Where(x => x.Groupe == groupe).ToList();

            lblTotal.Text = films.Count.ToString();

            GridViewMovie.DataSource = films;
            GridViewMovie.DataBind();
        }

        protected void btnValiderPasswordClick(object sender, EventArgs e)
        {
            if (txtPassword.Text.ToLower() == "ourson")
            {
                pnlOk.Visible = true;
                pnlPasOk.Visible = false;
            }
            else
            {
                pnlOk.Visible = false;
                pnlPasOk.Visible = true;
            }
        }

        protected void ddlGroupeChanged(object sender, EventArgs e)
        {

        }
    }
}