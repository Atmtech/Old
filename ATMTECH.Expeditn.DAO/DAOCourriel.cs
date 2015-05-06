using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Expeditn.DAO.Interface;
using ATMTECH.Expeditn.Entities;

namespace ATMTECH.Expeditn.DAO
{
    public class DAOCourriel : BaseDao<Courriel, int>, IDAOCourriel
    {
        public Courriel ObtenirMail(string code)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria { Column = Courriel.CODE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = code };
            criterias.Add(criteria1);
            criterias.Add(IsActive());
            SetLanguage(criterias, CurrentLanguage);

            IList<Courriel> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                return rtn[0];
            }
            return null;
        }

        
    }
}
