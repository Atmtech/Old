using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOParticipant : BaseDao<Participant, int>, IDAOParticipant
    {
        public IDAOUser DAOUser { get; set; }
       
        public IList<Participant> ObtenirParticipant(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Participant.EXPEDITION, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Participant> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                foreach (Participant participant in rtn)
                {
                    participant.Utilisateur = DAOUser.GetUser(participant.Utilisateur.Id);
                }

                return rtn;
            }
            return null;
        }

        public IList<Participant> ObtenirParticipant()
        {
            return GetAllActive();
        }

        public int Enregistrer(Participant participant)
        {
            return Save(participant);
        }
    }
}
