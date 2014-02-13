using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IValidateCustomerService
    {
        void IsValidCustomerOnCreate(Customer customer);
        void IsValidCustomerOnUpdate(Customer customer);
    }
}
