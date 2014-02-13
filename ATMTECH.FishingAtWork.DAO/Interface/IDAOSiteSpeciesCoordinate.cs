using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSiteSpeciesCoordinate
    {
        IList<SiteSpeciesCoordinate> GetArea(int siteId, int speciesId);
    }
}
