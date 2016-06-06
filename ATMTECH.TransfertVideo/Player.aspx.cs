using System;
using System.Linq;
using System.Web.UI;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;

namespace ATMTECH.TransfertVideo
{
    public partial class Player : Page
    {
        public string IdentifiantUnique
        {
            get
            {
                if (Session["IdentifiantUnique"] != null)
                { return Session["IdentifiantUnique"].ToString(); }
                return "";

            }
            set { Session["IdentifiantUnique"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                if (film != null)
                {
                    LiteralControl lit = new LiteralControl();
                    lit.Text = "<video width='800' controls><source src='http://twiggy.etouelle.com/Video/" + film.FichierMp4 + "' type='video/mp4'>Your browser does not support HTML5 video.</video>";
                    placeHolder.Controls.Add(lit);    
                }
                else
                {
                    LiteralControl lit = new LiteralControl();
                    lit.Text = "The movie you want to see don't exists";
                    placeHolder.Controls.Add(lit);    
                }
                
            }

        }


        protected void btnRevenirClick(object sender, EventArgs e)
        {
          Response.Redirect("Admin.aspx");
        }
    }
}