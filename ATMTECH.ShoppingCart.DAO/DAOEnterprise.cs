using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOEnterprise : BaseDao<Enterprise, int>, IDAOEnterprise
    {
        public IDAOEnterpriseAddress DAOEnterpriseAddress { get; set; }
        public IDAOFile DAOFile { get; set; }
        public IDAOCity DAOCity { get; set; }

        public Enterprise GetEnterprise(int idEntreprise)
        {
            Enterprise enterprise = GetById(idEntreprise);
    
            enterprise.BillingAddress = DAOEnterpriseAddress.GetBillingAddress(enterprise);
            enterprise.ShippingAddress = DAOEnterpriseAddress.GetShippingAddress(enterprise);
            enterprise.Image = DAOFile.GetFile(enterprise.Image.Id);
            return enterprise;
        }

        public IList<Enterprise> GetEnterprise()
        {
            return GetAllActive();
        }

        public int SaveEnterprise(Enterprise enterprise)
        {
            return Save(enterprise);
        }
    }
}
