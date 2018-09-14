using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.Expeditn.Views
{
    public class GererEtapePresenter : BaseExpeditnPresenter<IGererEtapePresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }

        public IDAOEtape DAOEtape { get; set; }
        public IDAOEtapeParticipant DAOEtapeParticipant { get; set; }
        public IDAOVehicule DAOVehicule { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }

        public GererEtapePresenter(IGererEtapePresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            View.Expedition = expedition;
            View.ListeVehicule = DAOVehicule.ObtenirVehicule();
            AfficherEtape(expedition);
        }

        private void AfficherEtape(Expedition expedition)
        {
            View.ListeEtape = DAOEtape.ObtenirEtape(expedition);
        }

        public void AjouterEtape()
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Vehicule vehicule = DAOVehicule.ObtenirVehicule(Convert.ToInt32(View.IdVehicule));
            Etape etape = new Etape
            {
                Nom = View.Nom,
                Debut = View.Debut,
                Fin = View.Fin,
                Distance = Convert.ToInt32(String.IsNullOrEmpty(View.Distance) ? "0" : View.Distance),
                Expedition = expedition,
                Vehicule = vehicule
            };
            DAOEtape.Enregistrer(etape);
            AfficherEtape(expedition);
        }

        public void RetirerEtape(string idEtape)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Etape etape = DAOEtape.ObtenirEtape(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(idEtape));
            if (etape.EtapeParticipant != null)
            {
                foreach (EtapeParticipant etapeParticipant in etape.EtapeParticipant)
                {
                    etapeParticipant.IsActive = false;
                    DAOEtapeParticipant.Enregistrer(etapeParticipant);
                }
            }
            etape.IsActive = false;
            DAOEtape.Enregistrer(etape);
            AfficherEtape(expedition);
        }

        public void RetirerEtapeParticipant(int idEtape, int idEtapeParticipant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Etape etape = DAOEtape.ObtenirEtape(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(idEtape));
            if (etape.EtapeParticipant != null)
            {
                EtapeParticipant etapeParticipant = DAOEtapeParticipant.ObtenirEtapeParticipant(etape).FirstOrDefault(x => x.Id == idEtapeParticipant);
                etapeParticipant.IsActive = false;
                DAOEtapeParticipant.Enregistrer(etapeParticipant);
            }
            AfficherEtape(expedition);
        }

        public void AjouterEtapeParticipant(int idParticipant, int idEtape)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Participant participant = DAOParticipant.ObtenirParticipant(expedition).FirstOrDefault(x => x.Id == idParticipant);
            Etape etape = DAOEtape.ObtenirEtape(expedition).FirstOrDefault(x => x.Id == idEtape);
            EtapeParticipant etapeParticipant = new EtapeParticipant
            {
                Participant = participant,
                Etape = etape,
                MontantVehicule = 0,
                MontantAutre = 0
            };
            DAOEtapeParticipant.Enregistrer(etapeParticipant);
            AfficherEtape(expedition);
        }

        public void RedirigerPageGererNourriture()
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = View.IdExpedition });
            NavigationService.Redirect(Pages.GERER_NOURRITURE, queryStrings);
        }
    }
}