using System.Collections.Generic;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class SiteService : BaseService, ISiteService
    {
        public IDAOSite DAOSite { get; set; }
        public IList<Site> GetSiteList()
        {
            return DAOSite.GetSiteList();
        }

        public Site GetSite(int id)
        {
            return DAOSite.GetSite(id);
        }

        public int GetPlayerCountSite(Site site)
        {
            return 1;
        }
    }
}
