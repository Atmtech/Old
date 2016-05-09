using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSpecies
    {
        Species GetSpecies(int id);
        IList<Species> GetSpecies();
    }
}
