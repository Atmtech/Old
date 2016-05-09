using System.Collections.Generic;
using System.Linq;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.DAO
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

        public IList<PlayerDTO> GetRanking(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = Player.EXPERIENCE, OrderByType = OrderBy.Type.Descending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = indexDebutRangee, PageSize = nbEnreg };
            IList<Player> players = GetAllActive(pagingOperation, orderOperation);

            IList<PlayerDTO> playerDtos = new List<PlayerDTO>();
            int i = 0;
            foreach (Player player in players)
            {
                player.User = DAOUser.GetUser(player.User.Id);

                i++;
                PlayerDTO playerDto = new PlayerDTO();
                playerDto.Player = player;
                playerDto.Rank = i;
                playerDto.Id = player.Id;
                playerDtos.Add(playerDto);
            }
            return playerDtos;
        }

        public int GetPlayerCount()
        {
            return GetCount();
        }

        public IList<Player> GetPlayer()
        {
            IList<Player> players = GetAllActive();
            foreach (Player player in players)
            {
                player.User = DAOUser.GetUser(player.User.Id);
            }

            return players.Where(x => x.User.IsActive).OrderBy(x => x.Level).ToList();
        }


    }
}
