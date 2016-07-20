using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantBateauExpedition : BaseDao<ParticipantBateauExpedition, int>, IDAOParticipantBateauExpedition
    {
     
        public IList<ParticipantBateauExpedition> ObtenirParticipantBateauExpedition(int idExpedition)
        {
            return GetAllActive().ToList();
        }
    }
}
