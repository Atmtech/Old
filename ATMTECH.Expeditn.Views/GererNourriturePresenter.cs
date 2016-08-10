using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Expeditn.DAO;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class GererNourriturePresenter : BaseExpeditnPresenter<IGererNourriturePresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        public IDAONourriture DAONourriture { get; set; }
        public IDAONourritureParticipant DAONourritureParticipant { get; set; }

        public GererNourriturePresenter(IGererNourriturePresenter view)
            : base(view)
        {
        }


        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            View.ListeParticipant = DAOParticipant.ObtenirParticipant(expedition);
            View.Expedition = expedition;
            AfficherNourriture(expedition);
        }
        public void AjouterMenu()
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Nourriture nourriture = new Nourriture
            {
                Expedition = expedition,
                Nom = View.Nom,
                Cuisinier = DAOParticipant.ObtenirParticipant(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdParticipantCuisinier)),
                Menu = View.Menu,
                Date = View.Date,

            };

            DAONourriture.Enregistrer(nourriture);
            AfficherNourriture(expedition);
        }
        public void RetirerNourriture(string idNourriture)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Nourriture nourriture = DAONourriture.ObtenirNourriture(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(idNourriture));
            nourriture.IsActive = false;
            DAONourriture.Enregistrer(nourriture);
            IList<NourritureParticipant> nourritureParticipants = DAONourritureParticipant.ObtenirNourritureParticipant(nourriture);
            foreach (NourritureParticipant nourritureParticipant in nourritureParticipants)
            {
                nourritureParticipant.IsActive = false;
                DAONourritureParticipant.Enregistrer(nourritureParticipant);
            }

            AfficherNourriture(expedition);
        }
        public void RetirerNourritureParticipant(int idNourriture, int idNourritureParticipant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Nourriture nourriture = DAONourriture.ObtenirNourriture(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(idNourriture));
            NourritureParticipant nourritureParticipant = DAONourritureParticipant.ObtenirNourritureParticipant(nourriture).FirstOrDefault(x => x.Id == idNourritureParticipant);
            nourritureParticipant.IsActive = false;
            DAONourritureParticipant.Enregistrer(nourritureParticipant);
            AfficherNourriture(expedition);
        }
        public void AjouterNourritureParticipant(int idParticipant, int idNourriture, string montant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Participant participant = DAOParticipant.ObtenirParticipant(expedition).FirstOrDefault(x => x.Id == idParticipant);
            Nourriture nourriture = DAONourriture.ObtenirNourriture(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(idNourriture));
            NourritureParticipant nourritureParticipant = new NourritureParticipant
            {
                Participant = participant,
                Nourriture = nourriture,
                Montant = Convert.ToDecimal(montant)
            };
            DAONourritureParticipant.Enregistrer(nourritureParticipant);
            AfficherNourriture(expedition);
        }
        private void AfficherNourriture(Expedition expedition)
        {
            View.ListeNourriture = DAONourriture.ObtenirNourriture(expedition);
        }
    }
}