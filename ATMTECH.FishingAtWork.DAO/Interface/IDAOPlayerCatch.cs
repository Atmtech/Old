using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOPlayerCatch
    {
        PlayerCatch GetPlayerCatch(Species species, Site site, Player player);
        void SavePlayerCatch(PlayerCatch playerCatch);
    }
}
