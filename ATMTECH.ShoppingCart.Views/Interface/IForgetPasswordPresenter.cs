using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IForgetPasswordPresenter : IViewBase
    {
        string Email { get; set; }
    }
}
