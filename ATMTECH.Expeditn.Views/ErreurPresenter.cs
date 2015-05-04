using ATMTECH.Expeditn.Views.Base;
using ATMTECH.Expeditn.Views.Interface;

namespace ATMTECH.Expeditn.Views
{
    public class ErreurPresenter : BaseExpeditnPresenter<IErreurPresenter>
    {

        public ErreurPresenter(IErreurPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherMessage();
        }

        public void RetourAccueil()
        {
            NavigationService.Redirect(Pages.DEFAULT);
        }

        public void AfficherMessage()
        {
            View.AfficherMessage();
        }
    }
}