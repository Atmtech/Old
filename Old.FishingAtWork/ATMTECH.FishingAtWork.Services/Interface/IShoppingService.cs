using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;

namespace ATMTECH.FishingAtWork.Services.Interface
{
    public interface IShoppingService
    {
        void Buy(int basketType, int id, int quantity);

    }
}
