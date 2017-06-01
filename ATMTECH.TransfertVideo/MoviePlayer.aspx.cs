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
        public const string WIDTH_PLAYER = "800";
        public const string HEIGHT_PLAYER = "600";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                if (film != null)
                {
                    LiteralControl lit = new LiteralControl();
                    if (!string.IsNullOrEmpty(film.Youtube))
                    {
                        string[] x = film.Youtube.Split('/');
                        string dernier = x[x.Length - 1];
                        dernier = dernier.Replace("watch?v=", "");
                        if (dernier.IndexOf("&") >= 0)
                            dernier = dernier.Substring(0, dernier.IndexOf("&"));
                        lit.Text = "<object data='http://www.youtube.com/embed/" + dernier + "' width='" + WIDTH_PLAYER + "' height='" + HEIGHT_PLAYER + "'></object>" + AfficherInformationFilm(film);
                        placeHolder.Controls.Add(lit);
                        new DAOFilm().MovieSeen(IdentifiantUnique);
                    }

                    if (!string.IsNullOrEmpty(film.Vimeo))
                    {
                        string[] x = film.Vimeo.Split('/');
                        string dernier = x[x.Length - 1];


                        lit.Text =
                            "<iframe src='https://player.vimeo.com/video/" + dernier + "' width='" + WIDTH_PLAYER + "' height='" + HEIGHT_PLAYER + "' frameborder='0' webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>" + AfficherInformationFilm(film);
                        placeHolder.Controls.Add(lit);
                        new DAOFilm().MovieSeen(IdentifiantUnique);
                    }

                    if (!string.IsNullOrEmpty(film.Dailymotion))
                    {
                        string[] x = film.Dailymotion.Split('/');
                        string dernier = x[x.Length - 1];
                        if (dernier.IndexOf("_") >= 0)
                            dernier = dernier.Substring(0, dernier.IndexOf("_"));
                        lit.Text = "<iframe frameborder='0' width='" + WIDTH_PLAYER + "' height='" + HEIGHT_PLAYER + "' src='//www.dailymotion.com/embed/video/" + dernier + "?PARAMS' allowfullscreen></iframe> " + AfficherInformationFilm(film);
                        placeHolder.Controls.Add(lit);
                        new DAOFilm().MovieSeen(IdentifiantUnique);
                    }


                }
                else
                {
                    LiteralControl lit = new LiteralControl();
                    lit.Text = "The movie you want to see don't exists";
                    placeHolder.Controls.Add(lit);
                }

            }
        }

        private string AfficherInformationFilm(Film film)
        {
            return
                string.Format(
                    "<div style='font-size:11px;'>Groupe: {0} | Étudiant 1: {1} | Étudiant 2: {2} | Étudiant 3: {3} | Étudiant 4: {4} | Étudiant 5: {5} | Étudiant 6: {6} | Style: {7}</div>", film.Groupe, film.Etudiant1, film.Etudiant2, film.Etudiant3, film.Etudiant4, film.Etudiant5, film.Etudiant6, film.Style);
        }

        protected void btnReturnClick(object sender, EventArgs e)
        {
            Response.Redirect("Administration.aspx");
        }


    }
}