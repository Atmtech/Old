using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.CalculPeche.Views.Interface
{
    public interface IAccueilPresenter : IViewBase
    {
        IList<Expedition> Expeditions { set; }
        IList<ParticipantPresenceExpedition> ParticipantPresenceExpeditions { set; }
        IList<ParticipantRepasExpedition> ParticipantRepasExpeditions { set; }
        IList<ParticipantBateauExpedition> ParticipantBateauExpeditions { set; }
        string ExpeditionSelectionne { get; set; }
    }
}
