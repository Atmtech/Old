using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Investisseurs.DAO.Interface;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.DAO
{
    public class DAOPlayerStockQuote : BaseDao<PlayerStockQuote, int>, IDAOPlayerStockQuote
    {

        public void AddPlayerStockQuote(PlayerStockQuote playerStockQuote)
        {
            Criteria criteria1 = new Criteria() { Column = PlayerStockQuote.PLAYER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = playerStockQuote.Player.Id.ToString() };
            Criteria criteria2 = new Criteria() { Column = PlayerStockQuote.SYMBOL, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = playerStockQuote.Symbol };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            IList<PlayerStockQuote> playerStockQuotes = GetByCriteria(criterias);
            
            if (playerStockQuotes.Count > 0)
            {
                int quantity = playerStockQuote.Quantity;
                playerStockQuote = playerStockQuotes[0];
                playerStockQuote.Quantity += quantity;
            }

            Save(playerStockQuote);
        }

       

    }

}
