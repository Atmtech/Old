using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSitePlayer : BaseDao<SitePlayer, int>, IDAOSitePlayer
    {
        public SitePlayer GetSitePlayer(int id)
        {
            return new SitePlayer();
        }

        public IList<SitePlayer> GetListSitePlayer(Site site)
        {
            return new List<SitePlayer>();
        }
    }
}
