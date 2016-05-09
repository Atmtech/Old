using System.Collections.Generic;
using ATMTECH.DAO;
using ATMTECH.DAO.Database;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSiteSpeciesCoordinate : BaseDao<SiteSpeciesCoordinate, int>, IDAOSiteSpeciesCoordinate
    {
        public IList<SiteSpeciesCoordinate> GetArea(int siteId, int speciesId)
        {
            Criteria criteria1 = new Criteria() { Column = SiteSpeciesCoordinate.SITE, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = siteId.ToString() };
            Criteria criteria2 = new Criteria() { Column = SiteSpeciesCoordinate.SPECIES, Operator = DatabaseOperator.OPERATOR_EQUAL, Value = speciesId.ToString() };
            IList<Criteria> criterias = new List<Criteria>();
            criterias.Add(criteria1);
            criterias.Add(criteria2);
            return GetByCriteria(criterias);
        }
    }
}
