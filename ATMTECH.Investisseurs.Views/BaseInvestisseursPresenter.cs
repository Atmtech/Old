using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.Investisseurs.Views
{
    public class BaseInvestisseursPresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseInvestisseursPresenter(TView view)
            : base(view)
        {
        }
    }
}
