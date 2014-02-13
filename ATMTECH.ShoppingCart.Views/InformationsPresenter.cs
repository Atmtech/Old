using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class InformationsPresenter : BaseShoppingCartPresenter<IInformationsPresenter>
    {

        public IEnterpriseService EnterpriseService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public InformationsPresenter(IInformationsPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();

            Customer customer = CustomerService.AuthenticateCustomer;
            if (customer != null)
            {
                switch (LocalizationService.CurrentLanguage)
                {
                    case LocalizationLanguage.FRENCH:
                        View.InformationDisplay = EnterpriseService.GetEnterprise(customer.Enterprise.Id).FrenchInformation;
                        break;
                    case LocalizationLanguage.ENGLISH:
                        View.InformationDisplay = EnterpriseService.GetEnterprise(customer.Enterprise.Id).EnglishInformation;
                        break;
                }
            }
        }
    }
}
