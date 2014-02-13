using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.Achievement.Views.Base
{
    public class BaseAccomplissementPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseAccomplissementPresenter(TView view)
            : base(view)
        {
        }


    }
}
