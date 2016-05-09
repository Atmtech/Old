using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class WallPostService : BaseService, IWallPostService
    {
        public IDAOWallPost DAOWallPost { get; set; }

        public int WritePost(WallPost wallPost)
        {
            return DAOWallPost.WritePost(wallPost);
        }

        public int GetWallPostCount()
        {
            return DAOWallPost.GetWallPostCount();
        }
        public IList<WallPostDTO> GetWallPost(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            IList<WallPostDTO> rtn = DAOWallPost.GetWallPost(parametreTrie, nbEnreg, indexDebutRangee);
            return rtn;
        }
    }
}
