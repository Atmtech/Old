using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ErreurPresenter : BaseShoppingCartPresenter<IErreurPresenter>
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
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }

        public void AfficherMessage()
        {
            View.AfficherMessage();
        }
    }
}