using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSiteSpecies
    {
        IList<SiteSpecies> GetSiteSpecies(Site site);
    }
}
