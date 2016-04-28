using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOPlayer
    {
        Player GetPlayer(int id);
        Player SavePlayer(Player player);
        int CreatePlayer(Player player);
        IList<PlayerDTO> GetRanking(string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetPlayerCount();
        IList<Player> GetPlayer();
       
    }
}
