using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOAdresseEntreprise : BaseDao<EnterpriseAddress, int>, IDAOAdresseEntreprise
    {
        public IList<EnterpriseAddress> ObtenirAdresse(Enterprise enterprise)
        {
            return GetBySql(string.Format("SELECT * FROM EnterpriseAddress WHERE Enterprise = {0}", enterprise.Id));
        }
    }
}
