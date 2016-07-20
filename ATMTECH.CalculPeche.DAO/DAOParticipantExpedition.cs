using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantExpedition : BaseDao<ParticipantExpedition, int>, IDAOParticipantExpedition
    {
        public IList<ParticipantExpedition> ObtenirParticipantExpedition(int idExpedition)
        {
            return GetAllActive().ToList();
        }
    }
}
