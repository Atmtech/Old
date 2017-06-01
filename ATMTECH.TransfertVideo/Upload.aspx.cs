using System;
using System.Linq;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;
using CuteWebUI;

namespace ATMTECH.TransfertVideo
{
    public partial class Upload : PageMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string identifiantUnique = IdentifiantUnique;
        }

        protected void Uploader_FileUploaded(object sender, UploaderEventArgs args)
        {
            //if (!string.IsNullOrEmpty(IdentifiantUnique))
            //{
            //    Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
            //    film.Fichier = IdentifiantUnique + "_" + args.FileName;
            //    new DAOFilm().Enregistrer(film);

            //    string repertoire = Server.MapPath("/Video/");
            //    args.CopyTo(repertoire + film.Fichier);

            //    Response.Redirect("ThankYou.aspx");
            //}
        }

      
        protected void btnSaveYoutubeClick(object sender, EventArgs e)
        {
            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
            film.Youtube = txtYoutube.Text;
            new DAOFilm().Enregistrer(film);
            Response.Redirect("ThankYou.aspx");
        }

        protected void btnSaveVimeoClick(object sender, EventArgs e)
        {
            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
            film.Vimeo = txtVimeo.Text;
            new DAOFilm().Enregistrer(film);
            Response.Redirect("ThankYou.aspx");
        }

        protected void btnSaveDailymotionClick(object sender, EventArgs e)
        {
            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
            film.Dailymotion = txtDailymotion.Text;
            new DAOFilm().Enregistrer(film);
            Response.Redirect("ThankYou.aspx");
        }
    }
}