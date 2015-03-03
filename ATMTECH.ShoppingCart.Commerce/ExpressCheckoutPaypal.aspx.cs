using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ExpressCheckoutPaypal : PageBase<ExpressCheckoutPaypalPresenter, IExpressCheckoutPaypalPresenter>, IExpressCheckoutPaypalPresenter
    {
        public PaypalReturn PaypalReturn { get; set; }
        public bool IsOrderFinalized { set; private get; }
        public string OrderDisplay { set; private get; }
    }
}