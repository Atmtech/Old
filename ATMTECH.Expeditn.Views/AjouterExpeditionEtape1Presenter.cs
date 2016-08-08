using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AjouterExpeditionEtape1Presenter : BaseExpeditnPresenter<IAjouterExpeditionEtape1Presenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IDAOGeoLocalisation DaoGeoLocalisation { get; set; }
        public IDAOPays DAOPays { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public AjouterExpeditionEtape1Presenter(IAjouterExpeditionEtape1Presenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.ListePays = DAOPays.ObtenirPays();
        }
        public int EnregistrerNouvelleExpedition()
        {
            Expedition expedition = new Expedition
            {
                Nom = View.Nom,
                Debut = View.Debut,
                Fin = View.Fin,
                BudgetEstime = View.BudgetEstime,
                EstPrive = View.EstExpeditionPrive,

            };
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
            expedition.Id = idExpedition;
            Participant participant = new Participant
            {
                Utilisateur = AuthenticationService.AuthenticateUser,
                Expedition = expedition,
                EstAdministrateur = true,
            };
            DAOParticipant.Enregistrer(participant);

            return idExpedition;
        }
        public void RedirigerEtape2(int idExpedition)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = idExpedition.ToString() });
            NavigationService.Redirect("AjouterExpeditionEtape2.aspx", queryStrings);
        }
    }
}