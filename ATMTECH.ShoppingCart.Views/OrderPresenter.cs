using System;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Views
{
    public class OrderPresenter : BaseShoppingCartPresenter<IOrderPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }


        public OrderPresenter(IOrderPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();

            Order order = OrderService.GetOrder(View.IdOrder);

            if (CustomerService.AuthenticateCustomer.User.Id == order.Customer.User.Id)
            {
                View.CurrentOrder = order;    
            }
        }
    }
}
