using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOCourriel : BaseDao<Mail, int>, IDAOCourriel
    {
        public Mail ObtenirMail(string code)
        {
            IList<Criteria> criterias = new List<Criteria>();
            Criteria criteria1 = new Criteria { Column = Mail.CODE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = code };
            criterias.Add(criteria1);
            criterias.Add(IsActive());
            SetLanguage(criterias, CurrentLanguage);

            IList<Mail> rtn = GetByCriteria(criterias);
            if (rtn.Count > 0)
            {
                return rtn[0];
            }
            return null;
        }

        
    }
}
