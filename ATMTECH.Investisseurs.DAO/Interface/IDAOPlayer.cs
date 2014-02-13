using System.Collections.Generic;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.DAO.Interface
{
    public interface IDAOPlayer
    {
        Player GetPlayer(int id);
        Player SavePlayer(Player player);
        int CreatePlayer(Player player);
        IList<Player> GetPlayer();
    }
}
