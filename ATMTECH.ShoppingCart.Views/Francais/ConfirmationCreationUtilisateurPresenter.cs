using ATMTECH.ShoppingCart.Services.Interface;
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

        public ICustomerService CustomerService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            View.EstConfirme = CustomerService.ConfirmCreate(View.IdConfirmationUtilisateur);
        }
    }
}