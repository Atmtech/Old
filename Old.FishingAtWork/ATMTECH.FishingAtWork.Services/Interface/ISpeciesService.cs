using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface ISpeciesService
    {
        IList<Species> GetSpecies();
    }
}
