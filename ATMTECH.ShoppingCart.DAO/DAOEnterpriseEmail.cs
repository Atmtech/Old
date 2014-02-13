using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOEnterpriseEmail : BaseDao<EnterpriseEmail, int>, IDAOEnterpriseEmail
    {
        public IList<EnterpriseEmail> GetEnterpriseEmail(Enterprise enterprise)
        {
            Criteria criteriaEnterprise = new Criteria { Column = EnterpriseEmail.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = enterprise.Id.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteriaEnterprise);
            criterias.Add(IsActive());
            
            return GetByCriteria(criterias);
        }
    }
}
