using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class LureService : BaseService, ILureService
    {
        public IDAOLure DAOLure { get; set; }
        public IDAOPlayerLure DAOPlayerLure { get; set; }
        public IPlayerService PlayerService { get; set; }
        public IList<LurePlayerLure> GetLureList(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<LurePlayerLure> lurePlayerLures = new List<LurePlayerLure>();
            IList<Lure> lures = DAOLure.GetLureList(parametreTrie, nbEnreg, indexDebutRangee);
            foreach (Lure lure in lures)
            {
                LurePlayerLure lurePlayerLure = new LurePlayerLure {Lure = lure, Id = lure.Id};
                PlayerLure playerLure = DAOPlayerLure.GetLure(PlayerService.AuthenticatePlayer, lure);
                if (playerLure == null)
                {
                    playerLure = new PlayerLure {Quantity = 0};
                }
                lurePlayerLure.PlayerLure = playerLure;
                lurePlayerLures.Add(lurePlayerLure);
            }
            return lurePlayerLures;
        }

        public IList<Lure> GetLureList()
        {
            return DAOLure.GetLureList();
        }

        public Lure GetLure(int id)
        {
            return DAOLure.GetLure(id);
        }
    }
}
