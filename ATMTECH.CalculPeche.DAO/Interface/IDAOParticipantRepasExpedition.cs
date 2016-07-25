using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOParticipantRepasExpedition
    {
        IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition);
        IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition();
        int Enregistrer(ParticipantRepasExpedition participantRepasExpedition);
    }
}
