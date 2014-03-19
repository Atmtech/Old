using ATMTECH.Views;
using ATMTECH.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Base
{
    public class BaseShoppingCartPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public IParameterService ParameterService { get; set; }
        
        public BaseShoppingCartPresenter(TView view)
            : base(view)
        {
           

        }

      

    }
}
