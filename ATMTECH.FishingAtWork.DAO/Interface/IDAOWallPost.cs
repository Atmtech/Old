using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOWallPost
    {
        int WritePost(WallPost wallPost);
        int GetWallPostCount();
        IList<WallPostDTO> GetWallPost(string parametreTrie, int nbEnreg, int indexDebutRangee);
    }
}
