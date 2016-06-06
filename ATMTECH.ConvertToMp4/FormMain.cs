using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ATMTECH.DAO.SessionManager;
using ATMTECH.TransfertVideo.DAO;
using ATMTECH.TransfertVideo.Entites;
using NReco.VideoConverter;

namespace ATMTECH.ConvertToMp4
{
    public partial class FormMain : Form
    {
        public string Resultat { set; get; }

        public FormMain()
        {
            InitializeComponent();
        }


        private void Convertir()
        {
            DatabaseSessionManager.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            string repertoireFilm = ConfigurationManager.AppSettings["RepertoireFilm"];
            IList<Film> obtenirListeFilm = new DAOFilm().ObtenirListeFilm().Where(x => x.FichierMp4 == null).ToList();
            FFMpegConverter ffMpegConverter = new FFMpegConverter();

            foreach (Film film in obtenirListeFilm)
            {
                string fichierInitial = string.Format("{0}\\{1}", repertoireFilm, film.Fichier);
                string fichierMp4 = string.Format("{0}\\{1}.mp4", repertoireFilm, film.FichierSansGuid);
                ffMpegConverter.ConvertMedia(fichierInitial, fichierMp4, Format.mp4);
                film.FichierMp4 = Path.GetFileName(fichierMp4);
                new DAOFilm().Enregistrer(film);
            }

            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Convertir();

        }
    }
}
