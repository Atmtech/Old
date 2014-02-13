using System.Collections.Generic;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.DAO.Interface
{
    public interface IDAOTransaction
    {
        void AddTransaction(Transaction transaction);
        double GetCurrentAccountBalance(Player player);
        IList<Transaction> GetAllStockHistory(Player player);
    }
}
