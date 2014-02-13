using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.Scrum.Views.Base
{
    public class BaseScrumPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseScrumPresenter(TView view)
            : base(view)
        {
        }


    }
}
