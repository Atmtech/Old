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
            AfficherInformation();
        }

        private void AfficherInformation()
        {
            if (View.Expedition == null) View.Expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            View.ListeParticipant = View.Expedition.Participant;
            View.Expedition = View.Expedition;
            View.ListeNourriture = View.Expedition.Nourriture;

            IList<DateTime> dates = new List<DateTime>();
            for (var dt = View.Expedition.Debut; dt <= View.Expedition.Fin; dt = dt.AddDays(1))
            {
                dates.Add(dt);
            }

            View.ListeDate = dates;
            if (!string.IsNullOrEmpty(View.IdNourriture))
            {
                Nourriture nourriture = DAONourriture.ObtenirNourriture(View.Expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdNourriture));
                View.Nom = nourriture.Nom;
                View.Menu = nourriture.Menu;
                View.Date = nourriture.Date;
                View.IdParticipantCuisinier = nourriture.Cuisinier.Id.ToString();
            }
            else
            {
                View.Nom = "";
                View.Menu = "";
                View.Date = View.Expedition.Debut;
            }
        }

        public void Enregistrer()
        {
            Nourriture nourriture = !string.IsNullOrEmpty(View.IdNourriture) ? DAONourriture.ObtenirNourriture(View.Expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdNourriture)) : new Nourriture();
            nourriture.Expedition = View.Expedition;
            nourriture.Nom = View.Nom;
            nourriture.Cuisinier = View.Expedition.Participant.FirstOrDefault(x => x.Id == Convert.ToInt32(View.IdParticipantCuisinier));
            nourriture.Menu = View.Menu;
            nourriture.Date = View.Date;
            DAONourriture.Enregistrer(nourriture);
            View.Expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherInformation();
        }
        public void RetirerNourriture(string idNourriture)
        {

            Nourriture nourriture = DAONourriture.ObtenirNourriture(View.Expedition).FirstOrDefault(x => x.Id == Convert.ToInt32(idNourriture));
            nourriture.IsActive = false;
            DAONourriture.Enregistrer(nourriture);
            IList<NourritureParticipant> nourritureParticipants = DAONourritureParticipant.ObtenirNourritureParticipant(nourriture);
            foreach (NourritureParticipant nourritureParticipant in nourritureParticipants)
            {
                nourritureParticipant.IsActive = false;
                DAONourritureParticipant.Enregistrer(nourritureParticipant);
            }

            View.Expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherInformation();
        }
        public void RetirerNourritureParticipant(int idNourriture, int idNourritureParticipant)
        {
            Nourriture nourriture = View.Expedition.Nourriture.FirstOrDefault(x => x.Id == Convert.ToInt32(idNourriture));
            NourritureParticipant nourritureParticipant = DAONourritureParticipant.ObtenirNourritureParticipant(nourriture).FirstOrDefault(x => x.Id == idNourritureParticipant);
            nourritureParticipant.IsActive = false;
            DAONourritureParticipant.Enregistrer(nourritureParticipant);
            View.Expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherInformation();
        }
        public void AjouterNourritureParticipant(int idParticipant, int idNourriture, string montant)
        {
            Participant participant = View.Expedition.Participant.FirstOrDefault(x => x.Id == idParticipant);
            Nourriture nourriture = View.Expedition.Nourriture.FirstOrDefault(x => x.Id == Convert.ToInt32(idNourriture));
            NourritureParticipant nourritureParticipant = new NourritureParticipant
            {
                Participant = participant,
                Nourriture = nourriture
            };
            DAONourritureParticipant.Enregistrer(nourritureParticipant);

            View.Expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            AfficherInformation();

        }
        public void ModifierNourriture(string idNourriture)
        {
            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString { Name = BaseEntity.ID, Value = View.IdExpedition });
            queryStrings.Add(new QueryString { Name = "IdNourriture", Value = idNourriture });
            NavigationService.Redirect(Pages.GERER_NOURRITURE, queryStrings);
        }


        public void ImprimerMenu()
        {
            ExpeditionService.ObtenirMenuPdf(View.Expedition);
        }
    }
}