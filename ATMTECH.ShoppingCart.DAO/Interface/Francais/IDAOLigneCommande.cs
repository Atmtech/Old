using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOLigneCommande
    {
        int Save(OrderLine orderLine);
        IList<OrderLine> ObtenirLigneCommande(Order commande);
        IList<OrderLine> GetAllActive();
    }
}
