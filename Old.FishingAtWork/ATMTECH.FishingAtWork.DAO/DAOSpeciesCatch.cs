using ATMTECH.DAO;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO
{
    public class DAOSpeciesCatch : BaseDao<SpeciesCatch, int>, IDAOSpeciesCatch
    {
        public int AddCatch(SpeciesCatch speciesCatch)
        {
            return Save(speciesCatch);
        }

        public int GetCountCatch(Site site)
        {
            return GetAllOneCriteria(SpeciesCatch.SITE, site.Id.ToString()).Count;
        }
    }
}
