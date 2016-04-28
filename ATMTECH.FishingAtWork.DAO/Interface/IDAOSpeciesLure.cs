using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.DAO.Interface
{
    public interface IDAOSpeciesLure
    {
        IList<SpeciesLure> GetSpeciesLure(Species species);
    }
}
