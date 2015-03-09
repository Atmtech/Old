using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOClient
    {
        Customer ObtenirClient(User user);
        Customer ObtenirClient(int id);
        int Creer(Customer customer);
        int Save(Customer customer);
    }
}
