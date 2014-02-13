using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Investisseurs.DAO.Interface;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.DAO
{
    public class DAOTransaction : BaseDao<Transaction, int>, IDAOTransaction
    {
        public void AddTransaction(Transaction transaction)
        {
            Save(transaction);
        }

        public double GetCurrentAccountBalance(Player player)
        {
            return GetAllStockHistory(player).Sum(x => x.Amount);
        }
        public IList<Transaction> GetAllStockHistory(Player player)
        {
            Criteria criteria1 = new Criteria() { Column = Transaction.PLAYER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = player.Id.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            IList<Transaction> transactions = GetByCriteria(criterias);
            return transactions;
        }

    }

}
