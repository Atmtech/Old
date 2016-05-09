using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IWallPostService
    {
        int WritePost(WallPost wallPost);
        IList<WallPostDTO> GetWallPost(string parametreTrie, int nbEnreg, int indexDebutRangee);
        int GetWallPostCount();
    }
}
