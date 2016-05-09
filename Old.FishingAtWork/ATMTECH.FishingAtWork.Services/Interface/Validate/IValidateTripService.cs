using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface.Validate
{
    public interface IValidateTripService
    {
        bool Validate(Trip trip);
    }
}
