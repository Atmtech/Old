using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSiteSpecies : BaseDao<SiteSpecies, int>, IDAOSiteSpecies
    {
        public IDAOSpecies DAOSpecies { get; set; }
        public IDAOSiteSpeciesCoordinate DAOSiteSpeciesCoordinate { get; set; }

        public IList<SiteSpecies> GetSiteSpecies(Site site)
        {
            IList<SiteSpecies> ret = new List<SiteSpecies>();

            IList<SiteSpecies> siteSpecieses = GetAllOneCriteria(SiteSpecies.SITE, site.Id.ToString());
            foreach (SiteSpecies siteSpeciese in siteSpecieses)
            {
                siteSpeciese.Species = DAOSpecies.GetSpecies(siteSpeciese.Species.Id);
                siteSpeciese.Area = DAOSiteSpeciesCoordinate.GetArea(siteSpeciese.Site.Id, siteSpeciese.Species.Id);
                ret.Add(siteSpeciese);
            }

            return ret;
        }
    }
}
