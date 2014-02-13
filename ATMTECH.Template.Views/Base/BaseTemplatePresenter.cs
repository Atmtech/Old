using ATMTECH.Views;
using ATMTECH.Views.Interface;

namespace ATMTECH.Template.Views.Base
{
    public class BaseTemplatePresenter<TView> : BasePresenter<TView> where TView : class, IViewBase
    {
        public BaseTemplatePresenter(TView view)
            : base(view)
        {
        }


    }
}
