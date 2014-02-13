using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface.Validate
{
    public interface IValidatePlayerService
    {
        void IsValidPlayerOnCreate(Player player);
        void IsValidPlayerOnUpdate(Player player);
    }
}
