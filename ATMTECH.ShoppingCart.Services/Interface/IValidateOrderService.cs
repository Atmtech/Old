using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IValidateOrderService
    {
        void IsValidOrder(Order order);
        void IsValidAddress(Order order);
        void IsValidIfOrderInformationIsEnabled(Order order);
    }
}
