using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSite
    {
        IList<Site> GetSiteList();
        Site GetSite(int id);
        Site SaveSite(Site site);
    }
}
