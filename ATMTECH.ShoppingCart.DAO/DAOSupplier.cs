using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOSupplier : BaseDao<Supplier, int>, IDAOSupplier
    {
        public Supplier GetSupplier(int id)
        {
            return GetById(id);
        }
    }
}
