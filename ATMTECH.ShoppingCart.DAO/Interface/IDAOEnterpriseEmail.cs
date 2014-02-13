using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOEnterpriseEmail
    {
        IList<EnterpriseEmail> GetEnterpriseEmail(Enterprise enterprise);

    }
}
