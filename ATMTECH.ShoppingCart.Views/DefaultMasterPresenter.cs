using System;
using System.Collections.Generic;
using ATMTECH.Common.Constant;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class DefaultMasterPresenter : BaseShoppingCartPresenter<IDefaultMasterPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IProductService ProductService { get; set; }

        public DefaultMasterPresenter(IDefaultMasterPresenter view)
            : base(view)
        {
        }

        public override void OnViewLoaded()
        {

            string isOffline = ParameterService.GetValue("IsOffline");
            if (!string.IsNullOrEmpty(isOffline))
            {
                if (isOffline == "1")
                {
                    NavigationService.Redirect("/Errors/Maintenance.html");
                }
            }

            Customer customer = CustomerService.AuthenticateCustomer;
            if (customer != null)
            {
                View.IsLogged = true;
                View.Name = customer.User.FirstNameLastName;

                decimal grandTotal = OrderService.GetGrandTotalFromOrderWishList(CustomerService.AuthenticateCustomer);
                View.TotalPrice = grandTotal;
                View.NumberOfItemInBasket = grandTotal == 0 ? 0 : OrderService.GetCountNumberOfItemInBasket(CustomerService.AuthenticateCustomer);

            }
        }



        public string ReturnLanguage()
        {
            return LocalizationService.CurrentLanguage;
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();


            // Développement 
            //AuthenticationService.SignIn("riov01", "test");

            Customer customer = CustomerService.AuthenticateCustomer;
            Enterprise enterprise;

            if (customer != null)
            {
                enterprise = CustomerService.AuthenticateCustomer.Enterprise;
                if (enterprise.Image != null)
                {
                    View.ImageCorp = enterprise.Image.FileName;
                }

                View.ProductCount = ProductService.GetProductCount(customer.Enterprise.Id);
            }
            else
            {
                enterprise = EnterpriseService.GetEnterprise(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
                if (enterprise.Image != null)
                {
                    View.ImageCorp = enterprise.Image.FileName;
                }

                View.ProductCount = ProductService.GetProductCount(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)));
            }

            View.Enterprise = enterprise;

            switch (CurrentLanguage)
            {
                case LocalizationLanguage.FRENCH:
                    View.Welcome = enterprise.FrenchWelcome;
                    View.Language = "English";
                    break;
                case LocalizationLanguage.ENGLISH:
                    View.Welcome = enterprise.EnglishWelcome;
                    View.Language = "Français";
                    break;
            }
        }

        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }

        public void Redirect(string page, IList<QueryString> queryStrings)
        {
            NavigationService.Redirect(page, queryStrings);
        }

        public void CloseSession()
        {
            AuthenticationService.SignOut();
            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }

        public void SetLanguage()
        {
            LocalizationService.CurrentLanguage = LocalizationService.CurrentLanguage == LocalizationLanguage.ENGLISH ?
                LocalizationLanguage.FRENCH : LocalizationLanguage.ENGLISH;

            switch (LocalizationService.CurrentLanguage)
            {
                case LocalizationLanguage.ENGLISH:
                    View.Language = "Français";
                    break;
                case LocalizationLanguage.FRENCH:
                    View.Language = "English";
                    break;
            }

            NavigationService.Redirect(Pages.Pages.DEFAULT);
        }

        public void SaveLocalization(IList<Localization> localizations)
        {
            LocalizationService.SaveLocalization(localizations);
        }

       
    }
}
