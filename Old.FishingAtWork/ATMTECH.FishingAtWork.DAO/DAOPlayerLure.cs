using System;
using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOPlayerLure : BaseDao<PlayerLure, int>, IDAOPlayerLure
    {
        public IDAOLure DAOLure { get; set; }
        public IList<Lure> GetLureList(Player player)
        {
            IList<Lure> lures = new List<Lure>();
            IList<PlayerLure> playerLures = GetAllOneCriteria(PlayerLure.PLAYER, player.Id.ToString());
            foreach (PlayerLure playerLure in playerLures)
            {
                Lure lure = DAOLure.GetLure(playerLure.Lure.Id);
                lures.Add(lure);
            }
            return lures;
        }

        public PlayerLure GetLure(Player player, Lure lure)
        {
            Criteria criteria1 = new Criteria() { Column = PlayerLure.LURE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = lure.Id.ToString() };
            Criteria criteria2 = new Criteria() { Column = PlayerLure.PLAYER, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = player.Id.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            IList<PlayerLure> playerLures = GetByCriteria(criterias);
            return playerLures[0];
        }
        public void AddLure(Player player, Lure lure, int quantity)
        {
            PlayerLure playerLure = GetLure(player, lure);
            if (playerLure != null)
            {
                playerLure.Quantity += quantity;
                Save(playerLure);
            }
            else
            {
                PlayerLure playerLureNew = new PlayerLure();
                playerLureNew.Lure = lure;
                playerLureNew.Player = player;
                playerLureNew.Quantity = quantity;
                Save(playerLureNew);
            }
        }
    }
}
