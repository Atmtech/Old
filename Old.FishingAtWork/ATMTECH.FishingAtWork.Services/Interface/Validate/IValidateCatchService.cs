using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface.Validate
{
    public interface IValidateCatchService
    {
        bool Validate(SpeciesCatch speciesCatch);
    }
}
