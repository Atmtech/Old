using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class ContacterNousPresenter : BaseShoppingCartPresenter<IContacterNousPresenter>
    {
        public IClientService ClientService { get; set; }
        public IMailService MailService { get; set; }

        public ContacterNousPresenter(IContacterNousPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Customer authenticateCustomer = ClientService.ClientAuthentifie;
            if ( authenticateCustomer!= null)
            {
                View.Courriel = authenticateCustomer.User.Email;
            }
        }

        public void EnvoyerMessage()
        {
            MailService.SendEmail(ParameterService.GetValue(Constant.ADMIN_MAIL), View.Courriel, "Une question en provenance du site web site web.", View.Message);
        }
    }
}
