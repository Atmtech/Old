using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Views
{
    public class ProductCatalogPresenter : BaseShoppingCartPresenter<IProductCatalogPresenter>
    {

        public ICustomerService CustomerService { get; set; }
        public IProductService ProductService { get; set; }

        public ProductCatalogPresenter(IProductCatalogPresenter view)
            : base(view)
        {
        }

        private void FindProductCategories()
        {
            IList<ProductCategory> productCategories;
            productCategories = CustomerService.AuthenticateCustomer != null ? 
                ProductService.GetProductCategory(CustomerService.AuthenticateCustomer.Enterprise.Id).OrderBy(x => x.OrderId).ToList() : 
                ProductService.GetProductCategory(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED))).OrderBy(x => x.OrderId).ToList();

            string idProductCategory = NavigationService.GetQueryStringValue(Pages.PagesId.PRODUCT_CATEGORY);

            if (!string.IsNullOrEmpty(idProductCategory))
            {
                productCategories = productCategories.Where(x => x.Id == Convert.ToInt32(idProductCategory)).ToList();
            }

            View.ProductCategories = productCategories;
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();

            FindProductCategories();

        }
        public IList<Product> GetProductCategory(int idProductCategory)
        {
            return CustomerService.AuthenticateCustomer != null ? ProductService.GetProducts(CustomerService.AuthenticateCustomer.Enterprise.Id, idProductCategory, CustomerService.AuthenticateCustomer.User.Id) : ProductService.GetProducts(Convert.ToInt32(ParameterService.GetValue(Constant.ID_ENTERPRISE_WHEN_NOT_AUTHENTIFIED)), idProductCategory);
        }

        public void OpenProduct(string idProduct)
        {
            IList<QueryString> queryStrings = new BindingList<QueryString>();
            queryStrings.Add(new QueryString(Pages.PagesId.PRODUCT_ID, idProduct));
            NavigationService.Redirect(Pages.Pages.PRODUCT_INFORMATION, queryStrings);
        }
    }
}
