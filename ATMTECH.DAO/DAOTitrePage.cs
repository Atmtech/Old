using System.Collections.Generic;
using ATMTECH.DAO.Database;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;

namespace ATMTECH.DAO
{
    public class DAOTitrePage : BaseDao<TitrePage, int>, IDAOTitrePage
    {
        public TitrePage ObtenirTitrePage(string page)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteriaMenu = new Criteria() { Column = TitrePage.PAGE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = page };
            criterias.Add(criteriaMenu);
            IList<TitrePage> contents = GetByCriteria(criterias);
            if (contents.Count > 0)
            {
                return contents[0];
            }
            return null;
        }
    }
}
