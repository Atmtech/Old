using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAONourritureParticipant : BaseDao<NourritureParticipant, int>, IDAONourritureParticipant
    {
        public IDAOParticipant DAOParticipant { get; set; }

        public IList<NourritureParticipant> ObtenirNourritureParticipant(Nourriture nourriture)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria { Column = NourritureParticipant.NOURRITURE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = nourriture.Id.ToString() };
            criterias.Add(criteria);
            criterias.Add(IsActive());
            IList<NourritureParticipant> nourritureParticipants = GetByCriteria(criterias);

            foreach (NourritureParticipant nourritureParticipant in nourritureParticipants)
            {
                if (nourritureParticipant.Participant != null)
                {
                    nourritureParticipant.Participant = nourriture.Expedition.Participant.FirstOrDefault(x => x.Id == nourritureParticipant.Participant.Id);
                }
                nourritureParticipant.Nourriture = nourriture;
            }
            return nourritureParticipants;
        }

        public int Enregistrer(NourritureParticipant nourritureParticipant)
        {
            return Save(nourritureParticipant);
        }
    }
}
