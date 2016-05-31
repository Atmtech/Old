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
               Refresh(); 
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
        }

        private void Refresh()
        {
            IList<Film> films = new DAOFilm().ObtenirListeFilm();
            lblTotal.Text = films.Count.ToString();

            GridViewMovie.DataSource = films;
            GridViewMovie.DataBind();    
        }

    }
}