using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOParticipant : BaseDao<Participant, int>, IDAOParticipant
    {
        public IDAOUser DAOUser { get; set; }
        public IDAOFile DAOFile { get; set; }

        public IList<Participant> ObtenirParticipant(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Participant.EXPEDITION, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Participant> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                IList<User> users = DAOUser.GetAllActive();
                IList<File> files = DAOFile.GetAllFile();
                foreach (Participant participant in rtn)
                {
                    participant.Utilisateur = users.FirstOrDefault(x => x.Id == participant.Utilisateur.Id);
                    participant.Utilisateur.Image = files.FirstOrDefault(x => x.Id == participant.Utilisateur.Image.Id);
                }

                return rtn;
            }
            return null;
        }

        public IList<Participant> ObtenirParticipant()
        {
            return GetAllActive();
        }

        public IList<Participant> ObtenirParticipant(User utilisateur)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Participant.UTILISATEUR, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = utilisateur.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            return GetByCriteria(criterias);
        }

        public int Enregistrer(Participant participant)
        {
            return Save(participant);
        }
    }
}
