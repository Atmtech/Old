using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface
{
    public interface IDAOEnterprise
    {
        Enterprise GetEnterprise(int idEntreprise);
        IList<Enterprise> GetEnterprise();
        int SaveEnterprise(Enterprise enterprise);
    }
}
