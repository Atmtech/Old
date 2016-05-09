using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface ISiteService
    {
        IList<Site> GetSiteList();
        Site GetSite(int id);
        int GetPlayerCountSite(Site site);
    }
}
