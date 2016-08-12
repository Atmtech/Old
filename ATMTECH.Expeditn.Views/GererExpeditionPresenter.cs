using System;
using System.Web;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class GererExpeditionPresenter : BaseExpeditnPresenter<IGererExpeditionPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IDAOGeoLocalisation DaoGeoLocalisation { get; set; }
        public IDAOPays DAOPays { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IFileService FileService { get; set; }

        public GererExpeditionPresenter(IGererExpeditionPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.ListePays = DAOPays.ObtenirPays();
            AfficherExpedition();

        }

        private void AfficherExpedition()
        {
            if (!string.IsNullOrEmpty(View.IdExpedition))
            {
                Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
                View.Nom = expedition.Nom;
                View.Debut = expedition.Debut;
                View.Fin = expedition.Fin;
                View.BudgetEstime = expedition.BudgetEstime;
                View.EstExpeditionPrive = expedition.EstPrive;

                View.Longitude = expedition.GeoLocalisation.Longitude;
                View.Latitude = expedition.GeoLocalisation.Latitude;
                View.Region = expedition.GeoLocalisation.Region;
                View.Pays = expedition.GeoLocalisation.Pays.Id.ToString();
                View.Ville = expedition.GeoLocalisation.Ville;
                View.Image = expedition.FichierImage;
            }
        }


        public int EnregistrerExpedition()
        {
            Expedition expedition = new Expedition
            {
                Nom = View.Nom,
                Debut = View.Debut,
                Fin = View.Fin,
                BudgetEstime = View.BudgetEstime,
                EstPrive = View.EstExpeditionPrive,

            };


            if (!string.IsNullOrEmpty(View.IdExpedition))
            {
                expedition.Id = Convert.ToInt32(View.IdExpedition);
            }

            if (!string.IsNullOrEmpty(View.Latitude) && !string.IsNullOrEmpty(View.Longitude))
            {
                GeoLocalisation geoLocalisation = new GeoLocalisation
                {
                    Longitude = View.Longitude,
                    Latitude = View.Latitude,
                    Region = View.Region,
                    Pays = new Pays { Id = Convert.ToInt32(View.Pays) },
                    Ville = View.Ville
                };

                int idGeoLocalization = DaoGeoLocalisation.Enregistrer(geoLocalisation);
                geoLocalisation.Id = idGeoLocalization;
                expedition.GeoLocalisation = geoLocalisation;
            }

            int idExpedition = ExpeditionService.Enregistrer(expedition);
            expedition = ExpeditionService.ObtenirExpedition(idExpedition);
            
            if (expedition.Participant == null)
            {
                Participant participant = new Participant
                {
                    Utilisateur = AuthenticationService.AuthenticateUser,
                    Expedition = expedition,
                    EstAdministrateur = true,
                };
                DAOParticipant.Enregistrer(participant);
            }

            return idExpedition;
        }

        public void EnregistrerImage(HttpPostedFile httpPostedFile)
        {
            int idFichier = FileService.SaveFile(httpPostedFile, @"\Images\Medias", View.RootPath);
            File file = FileService.GetFile(idFichier);
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            expedition.Image = file;
            ExpeditionService.Enregistrer(expedition);
            NavigationService.Refresh();
        }
    }
}