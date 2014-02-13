using ATMTECH.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IExpressCheckoutPaypalPresenter : IViewBase
    {
        PaypalReturn PaypalReturn { get; set; }
        bool IsOrderFinalized { set; }
        string OrderDisplay { set; }
    }
}
