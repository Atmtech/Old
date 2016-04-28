using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface ICatchService
    {
        IList<SpeciesCatch> Catch(Site site);
        int GetCountCatch(Site site);
    }
}
