using System.Collections.Generic;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.DAO.Interface
{
    public interface IDAOPlayerStockQuote
    {
        void AddPlayerStockQuote(PlayerStockQuote playerStockQuote);
    }
}
