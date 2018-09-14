using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class AdminPresenter : BaseExpeditnPresenter<IAdminPresenter>
    {

        public AdminPresenter(IAdminPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
    //        AfficherListeExpedition();
        }

    }

  
}