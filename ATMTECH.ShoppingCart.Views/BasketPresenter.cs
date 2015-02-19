using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.Web.Services;
using System.Linq;
using ErrorCode = ATMTECH.ShoppingCart.Services.ErrorCode;

namespace ATMTECH.ShoppingCart.Views
{
    public class BasketPresenter : BaseShoppingCartPresenter<IBasketPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }
        public IAddressService AddressService { get; set; }

        public ATMTECH.Services.Interface.IReportService ReportService { get; set; }

        public BasketPresenter(IBasketPresenter view)
            : base(view)
        {
        }


        public override void OnViewInitialized()
        {
            base.OnViewInitialized();

            Enterprise enterprise = CustomerService.AuthenticateCustomer.Enterprise;
            

            View.AskShippingLabel = MessageService.GetMessage(ErrorCode.SC_ASK_SHIPPING_QUOTATION).Description;
            View.IsDontAddPersonnalAddressBilling = enterprise.IsDontAddPersonnalAddressBilling;
            View.IsDontAddPersonnalAddressShipping = enterprise.IsDontAddPersonnalAddressShipping;

            if (NavigationService.GetQueryStringValue(PagesId.IS_ORDER_FINALIZED) == "1")
            {
                View.IsOrderFinalized = true;
            }
            else
            {
                View.CurrentOrder = OrderService.GetWishListFromCustomer(CustomerService.AuthenticateCustomer);

                if (enterprise.IsManageOrderInformation1)
                {
                    View.EnumOrderInformation1 = OrderService.GetOrderInformation(CustomerService.AuthenticateCustomer.Enterprise, "INFO1");
                    View.IsManageOrderInformation1 = true;
                }

                if (enterprise.IsManageOrderInformation2)
                {
                    View.EnumOrderInformation2 = OrderService.GetOrderInformation(CustomerService.AuthenticateCustomer.Enterprise, "INFO2");
                    View.IsManageOrderInformation2 = true;
                }

                if (View.CurrentOrder != null)
                {
                    AfficherAdresse(enterprise);
                    View.IsPaypal = View.CurrentOrder.Enterprise.IsPaypal;
                    View.IsPaypalRequired = View.CurrentOrder.Enterprise.IsPaypalRequired;
                    View.IsAskShipping = View.CurrentOrder.IsAskShipping;
                    View.IsOrderLocked = View.CurrentOrder.IsOrderLocked;
                    DisplayShipping();
                    if (View.CurrentOrder.OrderLines.Count(x => x.IsActive) > 0)
                    {
                        RecalculateBasket();
                    }
                }
            }
        }
        public void DisplayShipping()
        {
            View.IsShippingNotIncluded = !View.CurrentOrder.Enterprise.IsShippingIncluded;
            View.IsShippingManaged = View.CurrentOrder.Enterprise.IsShippingManaged;
            View.ShippingWeight = View.CurrentOrder.TotalWeight;

            if (View.CurrentOrder.Enterprise.ShippingCostFixed != 0)
            {
                View.ShippingTotal = View.CurrentOrder.Enterprise.ShippingCostFixed;
            }

            View.ShippingTotal = View.CurrentOrder.ShippingTotal;
        }
        public void RecalculateBasket()
        {
            if (View.CurrentOrder != null)
            {
                OrderService.UpdateOrder(View.CurrentOrder, GetShippingParameter());
                View.RefreshOrderDisplay(View.CurrentOrder);
                DisplayShipping();
            }
        }
        public void FinalizeOrder(bool isPaypal)
        {
            if (View.CurrentOrder != null)
            {
                OrderService.UpdateOrder(View.CurrentOrder, GetShippingParameter());
            }

            Order order = View.CurrentOrder;
            View.CurrentOrder.Project = View.Project;
            View.CurrentOrder.OrderInformation1 = View.OrderInformation1Value;
            View.CurrentOrder.OrderInformation2 = View.OrderInformation2Value;

            if (isPaypal)
            {
                View.CurrentOrder.IsPayPal = true;
            }

            if (!isPaypal)
            {
                OrderService.FinalizeOrder(View.CurrentOrder, GetShippingParameter());
            }
            else
            {
                OrderService.FinalizeOrderPaypal(View.CurrentOrder, GetShippingParameter());
            }

            IList<QueryString> queryStrings = new List<QueryString>();
            queryStrings.Add(new QueryString(PagesId.IS_ORDER_FINALIZED, "1"));
            queryStrings.Add(new QueryString(PagesId.ORDER_ID, order.Id.ToString()));
            NavigationService.Refresh(queryStrings);
        }
        public void RemoveOrderLine(int idOrderLine)
        {
            foreach (OrderLine orderLine in View.CurrentOrder.OrderLines)
            {
                if (orderLine.Id == idOrderLine)
                {
                    orderLine.IsActive = false;
                }
            }

            OrderService.UpdateOrderWithoutValidation(View.CurrentOrder, GetShippingParameter());
            NavigationService.Refresh();
        }
        public void PrintOrder()
        {
            Order order = OrderService.GetOrder(Convert.ToInt32(NavigationService.GetQueryStringValue(PagesId.ORDER_ID)));
            OrderService.PrintOrder(order);
        }
        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }
        public void AskForShipping()
        {
            OrderService.AskForShipping(View.CurrentOrder);
        }

        public void GotoAccount()
        {
            NavigationService.Redirect(Pages.Pages.CUSTOMER_INFORMATION);
        }
        public void SetBillingAddress(string selectedValue)
        {
            if (View.CurrentOrder.BillingAddress == null)
            {
                View.CurrentOrder.BillingAddress = new Address { Id = Convert.ToInt32(selectedValue) };
            }
            else
            {
                View.CurrentOrder.BillingAddress.Id = Convert.ToInt32(selectedValue);    
            }
            
            OrderService.UpdateOrder(View.CurrentOrder, GetShippingParameter());
            View.BillingAddressSelected = Convert.ToInt32(selectedValue);
        }
        public void SetShippingAddress(string selectedValue)
        {
            View.CurrentOrder.ShippingAddress.Id = Convert.ToInt32(selectedValue);
            OrderService.UpdateOrder(View.CurrentOrder, GetShippingParameter());
        }
        public void DisplayMandatoryAddress()
        {
            MessageService.ThrowMessage(ErrorCode.SC_NO_ADRESSE);
        }

        private ShippingParameter GetShippingParameterPurolator()
        {
            ShippingParameter shippingParameter = new ShippingParameter
            {
                BillingAccount = "99999999",
                CountryReceiverCode =
                    ParameterService.GetValue("CountryReceiverCode"),
                PackageType = PurolatorPackageType.EXPRESS_BOX,
                ServiceType = PurolatorServiceType.EXPRESS_BOX,
                SenderPostalCode =
                    ParameterService.GetValue("SenderPostalCode"),
                ShippingType = ShippingType.Purolator,
                WeightType = ShippingParameter.WeightTypes.Lbs,
                AccountId =
                    ParameterService.GetValue("PurolatorBillingAccount"),
                Login = ParameterService.GetValue("PurolatorUserName"),
                Password = ParameterService.GetValue("PurolatorPassword"),
                Url = ParameterService.GetValue("PurolatorWebServiceUrl")
            };

            return shippingParameter;
        }
        private ShippingParameter GetShippingParameter()
        {
            if (View.CurrentOrder.ShippingAddress == null)
            {
                return null;
            }

            return GetShippingParameterPurolator();
            // return View.CurrentOrder.ShippingAddress.Country.Code == "CAN" ? GetShippingParameterPurolator() : GetShippingParameterUps();
        }

        public void AfficherAdresse(Enterprise enterprise)
        {
            View.IsDontAddPersonnalAddressBilling = enterprise.IsDontAddPersonnalAddressBilling;
            View.IsDontAddPersonnalAddressShipping = enterprise.IsDontAddPersonnalAddressShipping;
            View.IsBillingAddressFixed = CustomerService.AuthenticateCustomer.Enterprise.IsBillingAddressFixed;
            View.IsShippingAddressFixed = CustomerService.AuthenticateCustomer.Enterprise.IsShippingAddressFixed;

            View.BillingAddress = AddressService.GetBillingAddress(CustomerService.AuthenticateCustomer);
            View.ShippingAddress = AddressService.GetShippingAddress(CustomerService.AuthenticateCustomer);

            //if (View.CurrentOrder.BillingAddress != null)
            //{
            //    View.BillingAddressSelected = View.CurrentOrder.BillingAddress.Id;
            //}

            //if (View.CurrentOrder.ShippingAddress != null)
            //{
            //    View.BillingAddressSelected = View.CurrentOrder.ShippingAddress.Id;
            //}

            View.NoAddressFound = MessageService.GetMessage(ErrorCode.SC_NO_ADRESSE).Description;
        }

    }
}
