using System;
using System.Collections.Generic;
using ATMTECH.Services;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.ShoppingCart.Views.Pages;
using ATMTECH.Web;
using ATMTECH.Web.Services;
using ATMTECH.Web.Services.Interface;
using System.Linq;

namespace ATMTECH.ShoppingCart.Views
{
    public class BasketPresenter : BaseShoppingCartPresenter<IBasketPresenter>
    {
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }
        public IAddressService AddressService { get; set; }
        public IParameterService ParameterService { get; set; }
        public ATMTECH.Services.Interface.IReportService ReportService { get; set; }

        public BasketPresenter(IBasketPresenter view)
            : base(view)
        {
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            if (NavigationService.GetQueryStringValue(PagesId.IS_ORDER_FINALIZED) == "1")
            {
                View.IsOrderFinalized = true;
            }
            else
            {
                View.CurrentOrder = OrderService.GetWishListFromCustomer(CustomerService.AuthenticateCustomer);

                if (CustomerService.AuthenticateCustomer.Enterprise.IsManageOrderInformation1)
                {
                    View.EnumOrderInformation1 = OrderService.GetOrderInformation(CustomerService.AuthenticateCustomer.Enterprise, "INFO1");
                    View.IsManageOrderInformation1 = true;
                }

                if (CustomerService.AuthenticateCustomer.Enterprise.IsManageOrderInformation2)
                {
                    View.EnumOrderInformation2 = OrderService.GetOrderInformation(CustomerService.AuthenticateCustomer.Enterprise, "INFO2");
                    View.IsManageOrderInformation2 = true;
                }

                if (View.CurrentOrder != null)
                {
                   
                    if (View.CurrentOrder.OrderLines.Count(x => x.IsActive) > 0)
                    {
                        RecalculateBasket();
                    }

                    
                    View.IsPaypalRequired = View.CurrentOrder.Enterprise.IsPaypalRequired;
                    View.IsAskShipping = View.CurrentOrder.IsAskShipping;
                }

               

            }


            
        }


        public void DisplayShipping()
        {
            View.IsShippingNotIncluded = !View.CurrentOrder.Enterprise.IsShippingIncluded;

            View.IsShippingManaged = View.CurrentOrder.Enterprise.IsShippingManaged;

            View.ShippingWeight = View.CurrentOrder.TotalWeight;
            View.ShippingTotal = View.CurrentOrder.ShippingTotal;
        }
        public void RecalculateBasket()
        {
            if (View.CurrentOrder != null)
            {
                FillAddress();
                View.Countrys = AddressService.GetAllCountries();
                OrderService.UpdateOrder(View.CurrentOrder, GetShippingParameter());
                View.RefreshOrderDisplay(View.CurrentOrder);
                DisplayShipping();
            }
        }
        public void FinalizeOrder(bool isPaypal)
        {
            Address addressBilling = SetModifyBillingAddress();
            Address addressShipping = SetModifyShippingAddress();

            View.CurrentOrder.Project = View.Project;
            View.CurrentOrder.OrderInformation1 = View.OrderInformation1Value;
            View.CurrentOrder.OrderInformation2 = View.OrderInformation2Value;

            if (isPaypal)
            {
                View.CurrentOrder.IsPayPal = true;
            }


            if (addressBilling != null)
            {
                View.CurrentOrder.BillingAddress = addressBilling;
            }

            if (addressShipping != null)
            {
                View.CurrentOrder.ShippingAddress = addressShipping;
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

            RecalculateBasket();
            NavigationService.Refresh();
        }
        public void PrintOrder()
        {
            OrderService.PrintOrder(View.CurrentOrder);
        }
        public void Redirect(string page)
        {
            NavigationService.Redirect(page);
        }

        private Address SetModifyShippingAddress()
        {
            if (View.IsPanelModifyShippingAddressOpen)
            {
                Address address = new Address
                {
                    City = new City { Code = View.ModifyShippingCity, Description = View.ModifyShippingCity },
                    PostalCode = View.ModifyShippingPostalCode,
                    Way = View.ModifyShippingAddressWay,
                    Country = AddressService.GetCountry(View.ModifyShippingCountry)
                };

                return AddressService.SaveAddress(address);
            }
            else
            {
                return AddressService.GetAddress(View.ShippingAddressSelected);
            }
        }
        private Address SetModifyBillingAddress()
        {
            if (View.IsPanelModifyBillingAddressOpen)
            {
                Address address = new Address
                {
                    City = new City { Code = View.ModifyBillingCity, Description = View.ModifyBillingCity },
                    PostalCode = View.ModifyBillingPostalCode,
                    Way = View.ModifyBillingAddressWay,
                    Country = AddressService.GetCountry(View.ModifyBillingCountry)
                };

                return AddressService.SaveAddress(address);
            }
            else
            {
                return AddressService.GetAddress(View.BillingAddressSelected);
            }
        }
        private void FillAddress()
        {
            if (View.CurrentOrder.ShippingAddress == null)
            {
                View.IsPanelModifyBillingAddressOpen = true;
                View.IsPanelModifyShippingAddressOpen = true;
            }

            View.BillingAddress = AddressService.GetBillingAddress(CustomerService.AuthenticateCustomer);
            View.ShippingAddress = AddressService.GetShippingAddress(CustomerService.AuthenticateCustomer);
            View.IsBillingAddressFixed = CustomerService.AuthenticateCustomer.Enterprise.IsBillingAddressFixed;
            View.IsShippingAddressFixed = CustomerService.AuthenticateCustomer.Enterprise.IsShippingAddressFixed;
        }
        private ShippingParameter GetShippingParameterUps()
        {
            ShippingParameter shippingParameter = new ShippingParameter
            {
                CountryReceiverCode = View.CurrentOrder.ShippingAddress.Country.Code,
                PackageType = ((int)UpsService.PackageType.Package).ToString(),
                SenderPostalCode = ParameterService.GetValue("SenderPostalCode"),
                ShippingType = ShippingType.Ups,
                ServiceCode = ((int)UpsService.ServiceCode.UpsWorldWidExpedited).ToString(),
                WeightType = ShippingParameter.WeightTypes.Lbs,
                AccountId = ParameterService.GetValue("UpsAccessLicenceNumber"),
                Login = ParameterService.GetValue("UpsUserId"),
                Password = ParameterService.GetValue("UpsPassword")
            };

            return shippingParameter;
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

        public void AskForShipping()
        {
           OrderService.AskForShipping(View.CurrentOrder);
           
        }
    }
}
