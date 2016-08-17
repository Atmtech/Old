using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAONourritureMontant : BaseDao<NourritureMontant, int>, IDAONourritureMontant
    {
        public IDAOParticipant DAOParticipant { get; set; }

        public IList<NourritureMontant> ObtenirNourritureMontant(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = NourritureMontant.EXPEDITION, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaMenu);
            criterias.Add(IsActive());
            IList<NourritureMontant> nourritureMontantInvestis = GetByCriteria(criterias);
            IList<Participant> participants = DAOParticipant.ObtenirParticipant(expedition);
            foreach (NourritureMontant nourritureMontantInvesti in nourritureMontantInvestis)
            {
                nourritureMontantInvesti.Participant =
                    participants.FirstOrDefault(x => x.Id == nourritureMontantInvesti.Participant.Id);
                nourritureMontantInvesti.Expedition = expedition;
            }
            return nourritureMontantInvestis;
        }

        public int Enregistrer(NourritureMontant nourritureMontant)
        {
            return Save(nourritureMontant);
        }
    }
}
