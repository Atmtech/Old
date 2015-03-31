using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOListeDistribution : BaseDao<ProductCategory, int>, IDAOListeDistribution
    {
        public int Save(MailingList mailingList)
        {
            return Save(mailingList);
        }
    }
}
