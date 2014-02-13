using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Base
{
    public class BaseShoppingCartPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseShoppingCartPresenter(TView view)
            : base(view)
        {
        }


    }
}
