using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Interface
{
    public interface IShippingService
    {
        decimal GetShippingTotal(Order order, ShippingParameter shippingParameter);
    }
}
