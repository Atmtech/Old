using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class BaseFishingAtWorkPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseFishingAtWorkPresenter(TView view)
            : base(view)
        {
        }
    }
}
