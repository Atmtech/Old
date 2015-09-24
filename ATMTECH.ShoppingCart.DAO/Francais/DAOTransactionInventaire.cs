using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.DAO.Francais
{
    public class DAOTransactionInventaire : BaseDao<StockTransaction, int>, IDAOTransactionInventaire
    {
        public IList<StockTransaction> ObtenirTransactionInventaire(Enterprise enterprise)
        {
            return GetBySql(string.Format("select * from StockTransaction WHERE Stock in (SELECT Id from Stock WHERE Product in (SELECT id FROM PRODUCT where Enterprise = {0}))", enterprise.Id));
        }
    }
}
