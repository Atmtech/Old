using System;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class GererBudgetPresenter : BaseExpeditnPresenter<IGererBudgetPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }

        public GererBudgetPresenter(IGererBudgetPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            View.Expedition = expedition;
            View.ListeAffichageSommeInvestis = ExpeditionService.ObtenirSommeInvesti(expedition);
            View.ListeParticipant = expedition.Participant;
            View.ListeRepartitionMontants = ExpeditionService.ObtenirRepartitionMontant(expedition);
            View.ListeMontantDu = ExpeditionService.ObtenirMontantDu(expedition);
        }


        public void RepartirNourriture(string idParticipant, decimal montant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            ExpeditionService.RepartirNourriture(expedition, idParticipant, montant);
            NavigationService.Refresh();
        }

        public void RepartirAutomobile(string idParticipant, decimal montant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            ExpeditionService.RepartirAutomobile(expedition, idParticipant, montant);
            NavigationService.Refresh();
        }

        public void RepartirBateau(string idParticipant, decimal montant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            ExpeditionService.RepartirBateau(expedition, idParticipant, montant);
            NavigationService.Refresh();
        }

        public void RepartirAutre(string idParticipant, decimal montant)
        {
            Expedition expedition = ExpeditionService.ObtenirExpedition(Convert.ToInt32(View.IdExpedition));
            ExpeditionService.RepartirAutre(expedition, idParticipant, montant);
            NavigationService.Refresh();
        }
    }
}