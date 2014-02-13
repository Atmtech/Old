using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.ErrorCode;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;

namespace ATMTECH.ShoppingCart.Views
{
    public class AddProductToBasketPresenter : BaseShoppingCartPresenter<IAddProductToBasketPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IProductService ProductService { get; set; }
        public IOrderService OrderService { get; set; }
        public IStockService StockService { get; set; }

        public AddProductToBasketPresenter(IAddProductToBasketPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            RefreshInformation();
        }
        public void AddToBasket(int idStock, int quantity)
        {
            if (GetCurrentOrderWishList() == 0)
            {
                CreateOrder(idStock, quantity);
            }
            else
            {
                AddToOrder(idStock, quantity);
            }
        }
        public void GetProductInformation()
        {
            if (View.IdProduct != null)
            {
                int idProduct;
                bool result = Int32.TryParse(View.IdProduct, out idProduct);

                if (result)
                {
                    Product product = ProductService.GetProduct(idProduct);
                    View.Product = product;
                    if (CustomerService.AuthenticateCustomer != null)
                    {
                        View.IsOrderable = CustomerService.AuthenticateCustomer.Enterprise.IsOrderPossible;
                        View.IsOrderableAgainstSecurity = ProductService.GetProductAccessOrderable(product, CustomerService.AuthenticateCustomer.Id); 
                    }
                    else
                    {
                        View.IsOrderable = false;
                    }
                }
                else
                {
                    MessageService.ThrowMessage(ErrorCode.SC_THIS_PRODUCT_NUMBER_DONT_EXIST);
                }
            }

        }
        public int GetActualStockState(Stock stock)
        {
            return StockService.GetCurrentStockStatus(stock);
        }
        public void RefreshInformation()
        {
            GetProductInformation();
            View.IsSuccesfullyAdded = Convert.ToInt32(QueryString.GetQueryStringValue(PagesId.SUCCESSFULLY_ADDED));
        }

        public ProductFile GetProductFile(int idProductFile)
        {
            if (View.IdProduct != null)
            {
                Product product = ProductService.GetProduct(Convert.ToInt32(View.IdProduct));
                foreach (ProductFile productFile in product.ProductFiles)
                {
                    if (productFile.Id == idProductFile)
                    {
                        return productFile;
                    }
                }
            }
            return null;
        }
        public void GetLinkedProduct(Product productLinked)
        {
            View.IdProduct = productLinked.Id.ToString();
            RefreshInformation();
        }
        public void RedirectBasket()
        {
            NavigationService.Redirect(Pages.Pages.BASKET);
        }
        public void RedirectProductCatalog()
        {
            NavigationService.Redirect(Pages.Pages.PRODUCT_CATALOG);
        }
        public void Redirect(string page, IList<QueryString> queryStrings)
        {
            NavigationService.Redirect(page, queryStrings);
        }

        private OrderLine CreateOrderLine(int idStock, int quantity)
        {
            OrderLine orderLine = new OrderLine { Stock = StockService.GetStock(idStock), Quantity = quantity };
            return orderLine;
        }
        private void CreateOrder(int idStock, int quantity)
        {
            Order order = new Order
            {
                Enterprise = CustomerService.AuthenticateCustomer.Enterprise,
                Customer = CustomerService.AuthenticateCustomer,
                CountryTax = CustomerService.AuthenticateCustomer.Taxes.CountryTax,
                RegionalTax = CustomerService.AuthenticateCustomer.Taxes.RegionalTax,
                OrderStatus = OrderStatus.IsWishList,
                OrderLines = new List<OrderLine>()
            };

            if (CustomerService.AuthenticateCustomer.Enterprise != null)
            {
                if (CustomerService.AuthenticateCustomer.Enterprise.BillingAddress.Count > 0)
                    order.BillingAddress = CustomerService.AuthenticateCustomer.Enterprise.BillingAddress[0];
                if (CustomerService.AuthenticateCustomer.Enterprise.ShippingAddress.Count > 0)
                    order.ShippingAddress = CustomerService.AuthenticateCustomer.Enterprise.ShippingAddress[0];
            }

            order = OrderService.AddOrderLine(CreateOrderLine(idStock, quantity), order);
            OrderService.CreateOrder(order, null);
        }
        private void AddToOrder(int idStock, int quantity)
        {
            Order order = OrderService.GetOrder(GetCurrentOrderWishList());
            order = OrderService.AddOrderLine(CreateOrderLine(idStock, quantity), order);
            OrderService.UpdateOrder(order, null);
        }
        private int GetCurrentOrderWishList()
        {
            Order order = OrderService.GetWishListFromCustomer(CustomerService.AuthenticateCustomer);
            return order != null ? order.Id : 0;
        }

    }
}
