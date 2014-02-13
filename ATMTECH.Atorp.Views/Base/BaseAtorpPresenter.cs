using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.Atorp.Views.Base
{
    public class BaseAtorpPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseAtorpPresenter(TView view)
            : base(view)
        {
        }
    }
}
