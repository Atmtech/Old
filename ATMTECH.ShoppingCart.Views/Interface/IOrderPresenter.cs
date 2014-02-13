using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IOrderPresenter : IViewBase
    {
        Order CurrentOrder { get; set; }
        int IdOrder { get; }
    }
}
