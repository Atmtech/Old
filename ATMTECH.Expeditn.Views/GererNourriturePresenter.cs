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
        public void Enregistrer()
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            Nourriture nourriture = !string.IsNullOrEmpty(View.IdNourriture) ? DAONourriture.ObtenirNourriture(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdNourriture)) : new Nourriture();
            nourriture.Expedition = expedition;
            nourriture.Nom = View.Nom;
            nourriture.Cuisinier = DAOParticipant.ObtenirParticipant(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdParticipantCuisinier));
            nourriture.Menu = View.Menu;
            nourriture.Date = View.Date;
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
        public void ModifierNourriture(string idNourriture)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = View.IdExpedition });
            queryStrings.Add(new QueryString { Name = "IdNourriture", Value = idNourriture });
            NavigationService.Redirect(Pages.GERER_NOURRITURE, queryStrings);
        }
        private void AfficherNourriture(Expedition expedition)
        {

            if (!string.IsNullOrEmpty(View.IdNourriture))
            {
                Nourriture nourriture = DAONourriture.ObtenirNourriture(expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdNourriture));
                View.Nom = nourriture.Nom;
                View.Menu = nourriture.Menu;
                View.Date = nourriture.Date;
                View.IdParticipantCuisinier = nourriture.Cuisinier.Id.ToString();
            }

            View.ListeNourriture = DAONourriture.ObtenirNourriture(expedition);
        }

        public void ImprimerMenu()
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            ExpeditionService.ObtenirMenuPdf(expedition);
        }
    }
}