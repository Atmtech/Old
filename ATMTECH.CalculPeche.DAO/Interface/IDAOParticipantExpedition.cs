using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOParticipantExpedition
    {
        IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition);
    }
}
