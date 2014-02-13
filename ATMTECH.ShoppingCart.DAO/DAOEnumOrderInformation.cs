using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOEnumOrderInformation : BaseDao<EnumOrderInformation, int>, IDAOEnumOrderInformation
    {
        public IList<EnumOrderInformation> GetOrderInformation(Enterprise enterprise, string group)
        {
            Criteria criteriaEnterprise = new Criteria { Column = EnumOrderInformation.ENTERPRISE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = enterprise.Id.ToString() };
            Criteria criteriaGroup = new Criteria { Column = EnumOrderInformation.GROUP, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = group };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteriaEnterprise);
            criterias.Add(criteriaGroup);
            criterias.Add(IsActive());
            return GetByCriteria(criterias);
        }

        public IList<EnumOrderInformation> GetOrderInformation()
        {
            return GetAllActive();
        }
    }
}
