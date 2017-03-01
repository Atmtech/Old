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
            if (!string.IsNullOrEmpty(IdentifiantUnique))
            {
                Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
                film.Fichier = IdentifiantUnique + "_" + args.FileName;
                new DAOFilm().Enregistrer(film);

                string repertoire = Server.MapPath("/Video/");
                args.CopyTo(repertoire + film.Fichier);

                Response.Redirect("ThankYou.aspx");
            }
        }

        private void Convert(string file)
        {
            //new FFMpegConverter().ConvertMedia(file, file + ".mp4", Format.mp4);
            //                   File.Delete(repertoire + film.Fichier);
            //                   film.Fichier = repertoire + film.Fichier;
            //                   new DAOFilm().Enregistrer(film);
            
        }

        protected void btnSaveYoutubeClick(object sender, EventArgs e)
        {
            Film film = new DAOFilm().ObtenirListeFilm().FirstOrDefault(x => x.Guid == IdentifiantUnique);
            film.Youtube = txtYoutube.Text;
            new DAOFilm().Enregistrer(film);
            Response.Redirect("ThankYou.aspx");
        }
    }
}