using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Investisseurs.DAO.Interface;
using ATMTECH.Investisseurs.Entities;

namespace ATMTECH.Investisseurs.DAO
{
    public class DAOPlayer : BaseDao<Player, int>, IDAOPlayer
    {
        public IDAOUser DAOUser { get; set; }
        public Player GetPlayer(int id)
        {
            Player player = GetById(id);
            player.User = DAOUser.GetUser(player.User.Id);
            return player;
        }

        public Player SavePlayer(Player player)
        {
            Save(player);
            return player;
        }

        public int CreatePlayer(Player player)
        {
            return Save(player);
        }

        public IList<Player> GetPlayer()
        {
            IList<Player> players = GetAllActive();
            foreach (Player player in players)
            {
                player.User = DAOUser.GetUser(player.User.Id);
            }

            return players.Where(x => x.User.IsActive).ToList();
        }


    }
}
