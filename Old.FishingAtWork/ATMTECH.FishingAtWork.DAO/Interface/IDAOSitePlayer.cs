using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSitePlayer
    {
        SitePlayer GetSitePlayer(int id);
        IList<SitePlayer> GetListSitePlayer(Site site);
    }
}
