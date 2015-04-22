using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOCommande
    {
        Order ObtenirCommandeSouhaite(Customer customer);
        Order ObtenirCommande(int id);
        IList<Order> ObtenirCommande(Customer customer);
        int Save(Order order);
        IList<Order> GetAllActive();
    }
}
