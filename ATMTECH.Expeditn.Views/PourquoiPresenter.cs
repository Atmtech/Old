using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class PourquoiPresenter : BaseExpeditnPresenter<IPourquoiPresenter>
    {
        public PourquoiPresenter(IPourquoiPresenter view)
            : base(view)
        {
        }

    }
}