using System;
using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Expeditn.Entities.DTO;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IGererBudgetPresenter : IViewBase
    {
        Expedition Expedition { set; }
        string IdExpedition { get; }
        IList<Participant> ListeParticipant { set; }
        IList<AffichageSommeInvesti> ListeAffichageSommeInvestis { set; }
        IList<AffichageRepartitionMontant> ListeRepartitionMontants { set; }
        IList<AffichageMontantDu> ListeMontantDu { set; }
    }
}
