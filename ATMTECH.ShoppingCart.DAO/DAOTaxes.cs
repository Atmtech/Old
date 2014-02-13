using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO
{
    public class DAOTaxes : BaseDao<Taxes, int>, IDAOTaxes
    {
        public Taxes GetTaxes(int id)
        {
            return GetById(id);
        }
        public Taxes GetTaxesByType(string type)
        {
            return GetAllOneCriteria(Taxes.TYPE, type)[0];
        }
    }
}
