using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOPlayerLure
    {
        IList<Lure> GetLureList(Player player);
        void AddLure(Player player, Lure lure, int quantity);
        PlayerLure GetLure(Player player, Lure lure);
    }
}
