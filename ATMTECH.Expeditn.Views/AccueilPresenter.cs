using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AccueilPresenter : BaseExpeditnPresenter<IAccueilPresenter>
    {
        public AccueilPresenter(IAccueilPresenter view)
            : base(view)
        {
        }

    }
}