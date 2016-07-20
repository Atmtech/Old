using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOParticipantPresenceExpedition
    {

        IList<ParticipantPresenceExpedition> ObtenirParticipantPresenceExpedition(int idExpedition);
       
    }
}
