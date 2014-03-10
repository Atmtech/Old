using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IEnterpriseService
    {
        Enterprise GetEnterprise(int id);
        IList<Enterprise> GetEnterprise();
        IList<Enterprise> GetEnterpriseByAccess(User user);
        void CreateEnterpriseFromAnother(int idEnterprise, string newName, User user);
        IList<Enterprise> GetAll();
        int Save(Enterprise enterprise);
    }
}
