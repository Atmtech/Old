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
        IList<ParticipantExpedition> ParticipantExpeditions { set; }
        IList<Repartition> Repartitions { set; }
        IList<MontantDu> MontantDus { set; }
            Expedition Expedition { set; }
        string ExpeditionSelectionne { get; set; }
    }
}
