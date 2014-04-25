using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.DenonceTonGros.Views.Base
{
    public class BaseDenonceTonGrosPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseDenonceTonGrosPresenter(TView view)
            : base(view)
        {
        }


    }
}
