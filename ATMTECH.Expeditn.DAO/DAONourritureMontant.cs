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

        public void InitialiserNourritureMontant(Expedition expedition)
        {
            foreach (Participant participant in expedition.Participant)
            {
                NourritureMontant nourritureMontant =
                    expedition.NourritureMontant.FirstOrDefault(x => x.Participant.Id == participant.Id) ??
                    new NourritureMontant
                    {
                        Participant = participant,
                        MontantInvesti = 0,
                        MontantTotalAPayer = 0,
                        Expedition = expedition
                    };

                Enregistrer(nourritureMontant);
            }
        }

        public void InitialiserNourritureMontantParticipant(Expedition expedition, int idParticipant, decimal montant)
        {
            ExecuteSql("UPDATE NourritureMontant SET MontantTotalAPayer = 0 WHERE Expedition = " + expedition.Id);

            NourritureMontant nourritureMontant = ObtenirNourritureMontant(expedition).FirstOrDefault(x => x.Participant.Id == idParticipant);
            nourritureMontant.MontantInvesti = montant;
            Enregistrer(nourritureMontant);
            
        }
    }
}
