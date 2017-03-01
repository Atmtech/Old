using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;

namespace ATMTECH.TransfertVideo
{
    public partial class MoviePlayer : PageMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                if (film != null)
                {
                    // Media_Player_Control1.MovieURL = Server.MapPath("Video") + @"\" + film.Fichier;
                    LiteralControl lit = new LiteralControl();
                    lit.Text = "<video width='800' controls><source src='http://" + HttpContext.Current.Request.Url.Authority + "/Video/" + film.Fichier + "'>Your browser does not support HTML5 video.</video>";
                    placeHolder.Controls.Add(lit);
                    new DAOFilm().MovieSeen(IdentifiantUnique);
                }
                else
                {
                    LiteralControl lit = new LiteralControl();
                    lit.Text = "The movie you want to see don't exists";
                    placeHolder.Controls.Add(lit);
                }

            }
        }

        protected void btnReturnClick(object sender, EventArgs e)
        {
            Response.Redirect("Administration.aspx");
        }

        
    }
}