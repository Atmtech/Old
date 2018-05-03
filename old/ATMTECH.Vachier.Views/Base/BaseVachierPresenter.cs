using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.Vachier.Views.Base
{
    public class BaseVachierPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseVachierPresenter(TView view)
            : base(view)
        {
        }


    }
}
