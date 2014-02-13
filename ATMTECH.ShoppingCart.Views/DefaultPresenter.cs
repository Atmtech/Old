using System;
using System.Collections.Generic;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class DefaultPresenter : BaseShoppingCartPresenter<IDefaultPresenter>
    {
        public IEnterpriseService EnterpriseService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IParameterService ParameterService { get; set; }

        public IOrderService OrderService { get; set; }


        public DefaultPresenter(IDefaultPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();

            Enterprise enterprise;

            Customer customer = CustomerService.AuthenticateCustomer;
            if (customer != null)
            {
                enterprise = customer.Enterprise;
                View.ContentValue = ExtractTheGoodContent(enterprise);
            }
            else
            {
                int idEnterprise = Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED));
                enterprise = EnterpriseService.GetEnterprise(idEnterprise);
                View.ContentValue = ExtractTheGoodContent(enterprise);
            }

            View.Enterprise = enterprise;
            View.FavoritesProduct = OrderService.GetFavoriteProductFromOrder(enterprise, 9);
        }

        private string ExtractTheGoodContent(Enterprise enterprise)
        {
            switch (View.QueryStringContent)
            {
                case Pages.ContentIdValue.CONTENT_CONTACT:
                    return LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH
                               ? enterprise.FrenchContact
                               : enterprise.EnglishContact;
                case Pages.ContentIdValue.CONTENT_INFORMATIONS:
                    return LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH
                          ? enterprise.FrenchInformation
                          : enterprise.EnglishInformation;
                case Pages.ContentIdValue.CONTENT_PUBLIC_RELATION:
                    return LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH
                          ? enterprise.FrenchPublicRelation
                          : enterprise.EnglishPublicRelation;
                case Pages.ContentIdValue.CONTENT_STEP:
                    return LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH
                          ? enterprise.FrenchStep
                          : enterprise.EnglishStep;
            }

            return LocalizationService.CurrentLanguage == LocalizationLanguage.FRENCH
                            ? enterprise.FrenchWelcome
                            : enterprise.EnglishWelcome;
        }

        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }

    }
}
