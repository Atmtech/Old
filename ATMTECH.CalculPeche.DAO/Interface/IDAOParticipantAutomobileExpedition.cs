using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOParticipantAutomobileExpedition
    {

        IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition(int idExpedition);
        IList<ParticipantAutomobileExpedition> ObtenirParticipantAutomobileExpedition();
        int Enregistrer(ParticipantAutomobileExpedition participantAutomobileExpedition);
    }
}
