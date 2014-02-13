using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOEnterpriseAccess
    {
        IList<EnterpriseAccess> GetEnterpriseAccess(User user);
        void SaveEnterpriseAccess(Enterprise enterprise, User user);
    }
}
