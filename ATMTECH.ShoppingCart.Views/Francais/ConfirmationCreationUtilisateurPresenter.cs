using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ConfirmationCreationUtilisateurPresenter :
        BaseShoppingCartPresenter<IConfirmationCreationUtilisateurPresenter>
    {
        public ConfirmationCreationUtilisateurPresenter(IConfirmationCreationUtilisateurPresenter view)
            : base(view)
        {
        }

        public IClientService ClientService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.EstConfirme = ClientService.EstConfirme(View.IdConfirmationUtilisateur);
        }
    }
}