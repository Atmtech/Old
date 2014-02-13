using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.BillardLoretteville.Views.Base
{
    public class BaseBillardLorettevillePresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseBillardLorettevillePresenter(TView view)
            : base(view)
        {
        }
    }
}
