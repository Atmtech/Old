using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IConfirmCreatePresenter : IViewBase
    {
        int IdConfirm { get; }
        bool IsConfirmed { set; }
    }
}
