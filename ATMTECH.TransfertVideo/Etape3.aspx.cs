using System;
using System.Linq;
using System.Web.UI;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;
using ATMTECH.Web;

namespace ATMTECH.TransfertVideo
{
    public partial class Etape3 : Page
    {

        public string IdentifiantUnique
        {
            get
            {
                if (Session["IdentifiantUnique"] == null)
                {
                    Session["IdentifiantUnique"] = string.Empty;
                }
                return Session["IdentifiantUnique"].ToString();
            }
            set { Session["IdentifiantUnique"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QueryString.GetQueryStringValue("Guid")))
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == QueryString.GetQueryStringValue("Guid"));
                lblRemerciement.Text = string.Format("{0} {1} {2} {3} {4} {5} for your movie {6}", film.Etudiant1, film.Etudiant2, film.Etudiant3, film.Etudiant4, film.Etudiant5, film.Etudiant6, film.Fichier);
            }
        }

    }
}