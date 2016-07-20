using System.Collections.Generic;
using ATMTECH.CalculPeche.Entities;

namespace ATMTECH.CalculPeche.DAO.Interface
{
    public interface IDAOParticipantBateauExpedition
    {

        IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition);
       
    }
}
