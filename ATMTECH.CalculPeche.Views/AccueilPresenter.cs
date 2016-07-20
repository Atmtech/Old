using System;
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
            AfficherPresenceExpedition();
            AfficherBateauExpedition();
            AfficherRepasExpedition();
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



    }
}