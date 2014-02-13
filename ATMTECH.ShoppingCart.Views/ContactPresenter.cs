using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class ContactPresenter : BaseShoppingCartPresenter<IContactPresenter>
    {

        public IEnterpriseService EnterpriseService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public ContactPresenter(IContactPresenter view)
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
                        View.ContactDisplay = EnterpriseService.GetEnterprise(customer.Enterprise.Id).FrenchContact;
                        break;
                    case LocalizationLanguage.ENGLISH:
                        View.ContactDisplay = EnterpriseService.GetEnterprise(customer.Enterprise.Id).EnglishContact;
                        break;
                }
            }
        }
    }
}
