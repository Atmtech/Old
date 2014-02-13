using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.SensArt.Views.Base
{
    public class BaseSensArtPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseSensArtPresenter(TView view)
            : base(view)
        {
        }


    }
}
