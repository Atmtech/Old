using System;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AjouterExpeditionEtape3Presenter : BaseExpeditnPresenter<IAjouterExpeditionEtape3Presenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IDAOEtape DAOEtape { get; set; }
        public IDAOEtapeParticipant DAOEtapeParticipant { get; set; }
        public IDAOVehicule DAOVehicule { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }

        public AjouterExpeditionEtape3Presenter(IAjouterExpeditionEtape3Presenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherEtape(expedition);
            View.ListeVehicule = DAOVehicule.ObtenirVehicule();
        }

        private void AfficherEtape(Expedition expedition)
        {
            View.ListeEtape = DAOEtape.ObtenirEtape(expedition);
        }

        public void AjouterActivite()
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Vehicule vehicule = DAOVehicule.ObtenirVehicule(Convert.ToInt32(View.IdVehicule));
            Etape etape = new Etape
            {
                Nom = View.Nom,
                Debut = View.Debut,
                Fin = View.Fin,
                Distance = Convert.ToInt32(View.Distance),
                Expedition = expedition,
                Vehicule = vehicule
            };
            DAOEtape.Enregistrer(etape);
            AfficherEtape(expedition);

        }

        public void RetirerEtape(string idEtape)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Etape etape = DAOEtape.ObtenirEtape(Convert.ToInt32(idEtape));
            foreach (EtapeParticipant etapeParticipant in etape.EtapeParticipant)
            {
                etapeParticipant.IsActive = false;
                DAOEtapeParticipant.Enregistrer(etapeParticipant);
            }
            etape.IsActive = false;
            DAOEtape.Enregistrer(etape);
            AfficherEtape(expedition);
        }

        public void RetirerEtapeParticipant(string idEtapeParticipant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            EtapeParticipant etapeParticipant = DAOEtapeParticipant.ObtenirEtapeParticipant(Convert.ToInt32(idEtapeParticipant));
            etapeParticipant.IsActive = false;
            DAOEtapeParticipant.Enregistrer(etapeParticipant);
            AfficherEtape(expedition);
        }

        public void AjouterEtapeParticipant(int idParticipant, int idEtape, string montant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Participant participant = DAOParticipant.ObtenirParticipant(Convert.ToInt32(idParticipant));
            Etape etape = DAOEtape.ObtenirEtape(Convert.ToInt32(idEtape));
            EtapeParticipant etapeParticipant = new EtapeParticipant
            {
                Participant = participant,
                Etape = etape,
                Montant = Convert.ToDecimal(montant)
            };
            DAOEtapeParticipant.Enregistrer(etapeParticipant);
            AfficherEtape(expedition);
        }
    }
}