using System;
using System.Linq;
using ATMTECH.CalculPeche.Services.Interface;
using ATMTECH.CalculPeche.Views.Base;
using ATMTECH.CalculPeche.Views.Interface;

namespace ATMTECH.CalculPeche.Views
{
    public class AccueilPresenter : BaseCalculPechePresenter<IAccueilPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }


        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherListeExpedition();
            Rafraichir();
        }

        public void Rafraichir()
        {

            if (!string.IsNullOrEmpty(View.ExpeditionSelectionne))
            {
                AfficherPresenceExpedition();
                AfficherAutomobileExpedition();
                AfficherBateauExpedition();
                AfficherRepasExpedition();
                AfficherArgentExpedition();
                AfficherExpedition();
                AfficherRepartition();
                AfficherMontantDu();
            }
        }

        private void AfficherAutomobileExpedition()
        {
            View.ParticipantAutomobileExpeditions = ExpeditionService.ObtenirParticipantAutomobileExpedition(Convert.ToInt32(View.ExpeditionSelectionne));
        }

        private void AfficherMontantDu()
        {
            View.MontantDus = ExpeditionService.ObtenirMontantDu(Convert.ToInt32(View.ExpeditionSelectionne));
        }

        private void AfficherArgentExpedition()
        {
            View.ParticipantExpeditions = ExpeditionService.ObtenirParticipantExpedition(Convert.ToInt32(View.ExpeditionSelectionne));
        }

        private void AfficherRepasExpedition()
        {
            View.ParticipantRepasExpeditions = ExpeditionService.ObtenirParticipantRepasExpedition(Convert.ToInt32(View.ExpeditionSelectionne));
        }

        private void AfficherBateauExpedition()
        {
            View.ParticipantBateauExpeditions = ExpeditionService.ObtenirParticipantBateauExpedition(Convert.ToInt32(View.ExpeditionSelectionne));
        }

        private void AfficherPresenceExpedition()
        {
            View.ParticipantPresenceExpeditions = ExpeditionService.ObtenirParticipantPresenceExpedition(Convert.ToInt32(View.ExpeditionSelectionne));
        }


        public void AfficherListeExpedition()
        {
            View.Expeditions = ExpeditionService.ObtenirExpedition();
        }

        public void AfficherExpedition()
        {
            View.Expedition = ExpeditionService.ObtenirExpedition().FirstOrDefault(x => x.Id == Convert.ToInt32(View.ExpeditionSelectionne));
        }

        public void AfficherRepartition()
        {
            View.Repartitions = ExpeditionService.ObtenirRepartition(Convert.ToInt32(View.ExpeditionSelectionne));
        }


        public void CreerExpedition(string nom, string dateDebut, string dateFin)
        {
            ExpeditionService.CreerExpedition(nom, dateDebut, dateFin);
            Rafraichir();
        }
    }
}