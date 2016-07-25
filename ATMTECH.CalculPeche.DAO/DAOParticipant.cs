using System.Collections.Generic;
using System.Linq;
using ATMTECH.CalculPeche.DAO.Interface;
using ATMTECH.CalculPeche.Entities;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;

namespace ATMTECH.CalculPeche.DAO
{
    public class DAOParticipant : BaseDao<Participant, int>, IDAOParticipant
    {

        public IList<Participant> ObtenirParticipant()
        {
            return GetAllActive().ToList();
        }

        public int Enregistrer(Participant participant)
        {
            return Save(participant);
        }
    }
}
