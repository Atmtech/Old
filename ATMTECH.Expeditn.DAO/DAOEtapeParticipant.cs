using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOEtapeParticipant : BaseDao<EtapeParticipant, int>, IDAOEtapeParticipant
    {
        public IDAOUser DAOUser { get; set; }
        public IDAOParticipant DAOParticipant { get; set; }
        

        public IList<EtapeParticipant> ObtenirEtapeParticipant(Etape etape)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = EtapeParticipant.ETAPE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = etape.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<EtapeParticipant> rtn = GetByCriteria(criterias);
            
            foreach (EtapeParticipant etapeParticipant in rtn)
            {
                if (etapeParticipant.Participant != null)
                {
                    etapeParticipant.Participant = DAOParticipant.ObtenirParticipant(etape.Expedition).FirstOrDefault(x => x.Id == etapeParticipant.Participant.Id);
                }
                etapeParticipant.Etape = etape;
                
            }
            return rtn.Count > 0 ? rtn : null;
        }


        public int Enregistrer(EtapeParticipant etapeParticipant)
        {
            return Save(etapeParticipant);
        }

    }
}
