using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipantRepasExpedition : BaseDao<ParticipantRepasExpedition, int>, IDAOParticipantRepasExpedition
    {
        public IList<ParticipantRepasExpedition> ObtenirParticipantRepasExpedition(int idExpedition)
        {
            return GetAllActive().ToList();
        }
    }
}
