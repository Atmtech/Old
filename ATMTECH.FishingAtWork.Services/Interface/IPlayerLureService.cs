using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IPlayerLureService
    {
        IList<Lure> GetLureList(Player player);
        void AddLure(Player player, Lure lure, int quantity);
    }
}
