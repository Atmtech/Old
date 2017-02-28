using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;
using CuteWebUI;
using NReco.VideoConverter;

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




        //protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        //{

        //    if (!string.IsNullOrEmpty(IdentifiantUnique))
        //    {
        //        if (e.FileSize < 1000)
        //        {
        //            string fichier = e.FileName;
        //            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
        //            film.Fichier = IdentifiantUnique + "_" + fichier;
        //            new DAOFilm().Enregistrer(film);
        //            AjaxFileUpload1.Attributes.Add("OnClientUploadComplete", "Return  OnClientUploadComplete");
        //            string repertoire = Server.MapPath("/Video/");
        //            AjaxFileUpload1.SaveAs(repertoire + film.Fichier);

        //            new FFMpegConverter().ConvertMedia(repertoire + film.Fichier, repertoire + film.Fichier + ".mp4", Format.mp4);
        //            File.Delete(repertoire + film.Fichier);
        //            film.Fichier = repertoire + film.Fichier;
        //            new DAOFilm().Enregistrer(film);
        //        }
        //        else
        //        {
        //            Response.Redirect("EtapeFichierTropVolumineux.aspx");


        //        }

        //    }
        //}



        protected void btnRevenirClick(object sender, EventArgs e)
        {
            Response.Redirect("Etape1.aspx");
        }


        protected void Uploader_FileUploaded(object sender, UploaderEventArgs args)
        {
            if (!string.IsNullOrEmpty(IdentifiantUnique))
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                film.Fichier = IdentifiantUnique + "_" + args.FileName;
                string repertoire = Server.MapPath("/Video/");
                args.CopyTo(repertoire + film.Fichier);
/*                new FFMpegConverter().ConvertMedia(repertoire + film.Fichier, repertoire + film.Fichier + ".mp4", Format.mp4);
                File.Delete(repertoire + film.Fichier);
                film.Fichier = repertoire + film.Fichier;
                new DAOFilm().Enregistrer(film);
  */
                Response.Redirect("Etape3.aspx");
            }
        }

        protected void btnSaveYoutubeClick(object sender, EventArgs e)
        {
            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
            film.Youtube = txtYoutube.Text;
            new DAOFilm().Enregistrer(film);
            Response.Redirect("Etape3.aspx");
        }
    }
}