using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOPays : BaseDao<Pays, int>, IDAOPays
    {
        public Pays ObtenirPays(int id)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaUser = new Criteria { Column = BaseEntity.ID, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = id.ToString() };
            criterias.Add(criteriaUser);
            criterias.Add(IsActive());
            IList<Pays> rtn = GetByCriteria(criterias);
            return rtn.Count > 0 ? rtn[0] : null;
        }

        public IList<Pays> ObtenirPays()
        {
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(IsActive());
            IList<Pays> rtn = GetByCriteria(criterias).OrderBy(x=>x.ComboboxDescription).ToList();
            return rtn.Count > 0 ? rtn : null;
        }
    }
}
