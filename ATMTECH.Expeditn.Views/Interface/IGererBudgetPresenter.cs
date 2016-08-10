using System;
using System.Collections.Generic;
using ATMTECH.Expeditn.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.Expeditn.Views.Interface
{
    public interface IGererBudgetPresenter : IViewBase
    {
        Expedition Expedition { set; }
        string IdExpedition { get;}
        IList<EtapeParticipant> ListeEtapeParticipant {set; }
        IList<NourritureParticipant> ListeNourritureParticipant { set; }
    }
}
