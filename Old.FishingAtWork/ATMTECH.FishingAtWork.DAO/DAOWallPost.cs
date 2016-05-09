using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOWallPost : BaseDao<WallPost, int>, IDAOWallPost
    {
        public IDAOPlayer DAOPlayer { get; set; }

        public int WritePost(WallPost wallPost)
        {
            return Save(wallPost);
        }


        public int GetWallPostCount()
        {
            return GetCount();
        }
        public IList<WallPostDTO> GetWallPost(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            OrderOperation orderOperation = new OrderOperation() { OrderByColumn = BaseEntity.ID, OrderByType = OrderBy.Type.Ascending };
            PagingOperation pagingOperation = new PagingOperation() { PageIndex = indexDebutRangee, PageSize = nbEnreg };
            IList<WallPost> wallPosts = GetAllActive(pagingOperation, orderOperation);
            IList<WallPostDTO> wallPostDtos = new List<WallPostDTO>();
            foreach (WallPost wallPost in wallPosts)
            {
                WallPostDTO wallPostDTO = new WallPostDTO();
                wallPostDTO.Id = wallPost.Id;
                wallPostDTO.Player = DAOPlayer.GetPlayer(wallPost.Player.Id);
                wallPostDTO.WallPost = wallPost;
                wallPostDtos.Add(wallPostDTO);
            }
            return wallPostDtos;
        }
    }
}
