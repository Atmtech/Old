using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOEtapeParticipant : BaseDao<EtapeParticipant, int>, IDAOEtapeParticipant
    {
        public IList<EtapeParticipant> ObtenirEtapeParticipant(Etape etape)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = EtapeParticipant.ETAPE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = etape.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<EtapeParticipant> rtn = GetByCriteria(criterias);
            return rtn.Count > 0 ? rtn : null;
        }

    }
}
