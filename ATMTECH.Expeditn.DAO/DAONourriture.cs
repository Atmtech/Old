using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAONourriture : BaseDao<Nourriture, int>, IDAONourriture
    {
        public IDAOParticipant DAOParticipant { get; set; }
        public IDAONourritureParticipant DAONourritureParticipant { get; set; }
      
        public IList<Nourriture> ObtenirNourriture(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = Nourriture.EXPEDITION, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Nourriture> rtn = GetByCriteria(criterias);
            foreach (Nourriture nourriture in rtn)
            {
                nourriture.Expedition = expedition;
                nourriture.Cuisinier = expedition.Participant.FirstOrDefault(x => x.Id == nourriture.Cuisinier.Id);
                nourriture.NourritureParticipant = DAONourritureParticipant.ObtenirNourritureParticipant(nourriture);
            }
            
            return rtn.Count > 0 ? rtn : null;
        }

        public int Enregistrer(Nourriture nourriture)
        {
            return Save(nourriture);
        }
    }
}
