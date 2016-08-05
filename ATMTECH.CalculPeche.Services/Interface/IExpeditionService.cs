using System.CodeDom.Compiler;
using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.Services.Interface
{
    public interface IExpeditionService
    {
        IList<Expedition> ObtenirExpedition();
        IList<Participant> ObtenirParticipant();
        IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition(int idExpedition);
        IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition();
        IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition);
        IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition();
        IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition);
        IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition();
        IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition();
        IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition(int idExpedition);
        IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition);
        IList<ParticipantExpedition> ObtenirParticipantExpedition();
        IList<Repartition> ObtenirRepartition(int idExpedition);
        IList<MontantDu> ObtenirMontantDu(int idExpedition);
        void CreerExpedition(string nom, string dateDebut, string dateFin);
        void RemettreSearch();
    }
}
