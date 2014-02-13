using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface.Validate
{
    public interface IValidateShoppingService
    {
        bool Validate(Player player, Lure lure, int quantity);
    }
}
