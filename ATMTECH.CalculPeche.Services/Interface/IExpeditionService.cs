using System.CodeDom.Compiler;
using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.Services.Interface
{
    public interface IExpeditionService
    {
        IList<Expedition> ObtenirExpedition();
        IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition(int idExpedition);
        IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition);
        IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition);
        IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition);
    }
}
