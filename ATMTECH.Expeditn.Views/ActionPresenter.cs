using ATMTECH.Expeditn.Services.Interface;
using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class ActionPresenter : BaseExpeditnPresenter<IActionPresenter>
    {
        public IExpeditionService ExpeditionService { get; set; }


        public ActionPresenter(IActionPresenter view)
            : base(view)
        {
        }

        
    }
}