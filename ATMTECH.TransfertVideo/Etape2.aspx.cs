using System;
using System.Linq;
using System.Web.UI;
using AjaxControlToolkit;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;
using ATMTECH.Web;

namespace ATMTECH.TransfertVideo
{
    public partial class Etape2 : Page
    {

        public string IdentifiantUnique
        {
            get
            {
                return Session["IdentifiantUnique"].ToString();
            }
            set { Session["IdentifiantUnique"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {

            if (!string.IsNullOrEmpty(IdentifiantUnique))
            {
                string fichier = e.FileName;
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                film.Fichier = IdentifiantUnique + "_" + fichier;
                new DAOFilm().Enregistrer(film);
                AjaxFileUpload1.Attributes.Add("OnClientUploadComplete", "Return  OnClientUploadComplete");
                string repertoire = Server.MapPath("/Video/");
                AjaxFileUpload1.SaveAs(repertoire + film.Fichier);
                pnluploader.Visible = false;
                

            }
        }

        protected void btnRevenirClick(object sender, EventArgs e)
        {
             Response.Redirect("Etape1.aspx");
        }

     
    }
}