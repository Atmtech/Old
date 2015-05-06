using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOEtape : BaseDao<Etape, int>, IDAOEtape
    {
        public IList<Etape> ObtenirEtape(Expedition expedition)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = expedition.Id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Etape> rtn = GetByCriteria(criterias);
            return rtn.Count > 0 ? rtn : null;
        }

    }
}
