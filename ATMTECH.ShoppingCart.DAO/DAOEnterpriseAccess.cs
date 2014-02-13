using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOEnterpriseAccess : BaseDao<EnterpriseAccess, int>, IDAOEnterpriseAccess
    {
        public IList<EnterpriseAccess> GetEnterpriseAccess(User user)
        {
            return GetAllActive();
        }

        public void SaveEnterpriseAccess(Enterprise enterprise, User user)
        {
            EnterpriseAccess enterpriseAccess = new EnterpriseAccess { Enterprise = enterprise, User = user };
            Save(enterpriseAccess);
        }
    }
}
