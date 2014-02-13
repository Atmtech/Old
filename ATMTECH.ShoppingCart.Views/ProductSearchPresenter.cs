using System;
using System.Collections.Generic;
using System.ComponentModel;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class ProductSearchPresenter : BaseShoppingCartPresenter<IProductSearchPresenter>
    {

        public ICustomerService CustomerService { get; set; }
        public IProductService ProductService { get; set; }
        public IParameterService ParameterService { get; set; }

        public ProductSearchPresenter(IProductSearchPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            if (!string.IsNullOrEmpty(View.Search))
            {
                Search(View.Search);
            }
        }

        public void Search(string search)
        {
            if (CustomerService.AuthenticateCustomer != null)
            {
                View.Products = ProductService.GetProducts(CustomerService.AuthenticateCustomer.Enterprise.Id,
                                                           CustomerService.AuthenticateCustomer.Id, search);
            }
            else
            {
                View.Products = ProductService.GetProducts(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)), 0, search);
            }
        }

        public void OpenProduct(string idProduct)
        {
            //IList<QueryString> queryStrings = new BindingList<QueryString>();
            //queryStrings.Add(new QueryString(Pages.PagesId.PRODUCT_ID, idProduct));
            //NavigationService.Redirect(Pages.Pages.PRODUCT_INFORMATION, queryStrings);
        }
    }
}
