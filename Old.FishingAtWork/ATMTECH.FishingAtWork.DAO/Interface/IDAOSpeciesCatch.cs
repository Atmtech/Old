using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSpeciesCatch
    {
        int AddCatch(SpeciesCatch speciesCatch);
        int GetCountCatch(Site site);
    }
}
