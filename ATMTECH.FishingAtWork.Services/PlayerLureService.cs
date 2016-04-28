using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class PlayerLureService : BaseService, IPlayerLureService
    {
        public IDAOPlayerLure DAOPlayerLure { get; set; }
        public IList<Lure> GetLureList(Player player)
        {
            return DAOPlayerLure.GetLureList(player);
        }

        public void AddLure(Player player, Lure lure, int quantity)
        {
            DAOPlayerLure.AddLure(player, lure, quantity);
        }
    }
}
