using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSite : BaseDao<Site, int>, IDAOSite
    {
        public IDAOSiteSpecies DAOSiteSpecies { get; set; }

        public IList<Site> GetSiteList()
        {
            IList<Site> sites = GetAllActive();
            foreach (Site site in sites)
            {
                FillSite(site);
            }
            return sites;
        }


        private Site FillSite(Site site)
        {
            site.SiteSpecies = DAOSiteSpecies.GetSiteSpecies(site);
            foreach (SiteSpecies siteSpeciese in site.SiteSpecies)
            {
                siteSpeciese.Site = site;
            }
            return site;
        }
        public Site GetSite(int id)
        {
            Site site = GetById(id);
            return FillSite(site);
        }

        public Site SaveSite(Site site)
        {
            Save(site);
            return site;
        }
    }
}
