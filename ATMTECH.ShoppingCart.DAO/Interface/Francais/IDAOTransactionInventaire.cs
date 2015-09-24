using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Interface.Francais
{
    public interface IDAOTransactionInventaire
    {
        IList<StockTransaction> ObtenirTransactionInventaire(Enterprise enterprise);
    }
}
