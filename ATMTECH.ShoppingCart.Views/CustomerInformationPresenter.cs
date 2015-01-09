using System;
using System.Collections.Generic;
using ATMTECH.Entities;
using ATMTECH.Services;
using ATMTECH.ShoppingCart.DAO.Interface;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Base;
using ATMTECH.ShoppingCart.Services.ErrorCode;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Reports.DTO;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface;
using ATMTECH.Web.Services.Interface;

namespace ATMTECH.ShoppingCart.Views
{
    public class CustomerInformationPresenter : BaseShoppingCartPresenter<ICustomerInformationPresenter>
    {

        public IAddressService AddressService { get; set; }
        public ICustomerService CustomerService { get; set; }
        public IOrderService OrderService { get; set; }
        public IDAOCity DAOCity { get; set; }

        public ATMTECH.Services.Interface.IReportService ReportService { get; set; }

        public CustomerInformationPresenter(ICustomerInformationPresenter view)
            : base(view)
        {

        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            Customer customer = CustomerService.AuthenticateCustomer;
            if (customer != null)
            {
               

                View.Name = customer.User.FirstNameLastName;
                View.FirstName = customer.User.FirstName;
                View.LastName = customer.User.LastName;
                View.Login = customer.User.Login;
                View.Password = customer.User.Password;
                View.PasswordConfirmation = customer.User.Password;
                View.Email = customer.User.Email;
                View.Countrys = AddressService.GetAllCountries();
                View.IsSuperUser = customer.User.IsSuperUser;
                View.IsDontAddPersonnalAddressShipping = customer.Enterprise.IsDontAddPersonnalAddressShipping;
                View.IsDontAddPersonnalAddressBilling = customer.Enterprise.IsDontAddPersonnalAddressBilling;

                if (customer.BillingAddress.Id != 0)
                {
                    View.BillingCity = customer.BillingAddress.City.Description;
                    View.BillingCountry = customer.BillingAddress.Country.Id.ToString();
                    View.BillingPostalCode = customer.BillingAddress.PostalCode;
                    View.BillingWay = customer.BillingAddress.Way;
                }
                if (customer.ShippingAddress.Id != 0)
                {
                    View.ShippingCity = customer.ShippingAddress.City.Description;
                    View.ShippingCountry = customer.ShippingAddress.Country.Id.ToString();
                    View.ShippingPostalCode = customer.ShippingAddress.PostalCode;
                    View.ShippingWay = customer.ShippingAddress.Way;
                }
                View.OrdersOrdered = OrderService.GetOrdersFromCustomer(customer, OrderStatus.IsOrdered);
                View.OrdersShipped = OrderService.GetOrdersFromCustomer(customer, OrderStatus.IsShipped);

                View.IsChangeAddressShippingPossible = CustomerService.AuthenticateCustomer.Enterprise.IsShippingAddressFixed;
                View.IsChangeAddressBillingPossible = CustomerService.AuthenticateCustomer.Enterprise.IsBillingAddressFixed;
            }
        }

        public void SaveCustomer()
        {
            Customer customer = CustomerService.AuthenticateCustomer;

            customer.User.FirstName = View.FirstName;
            customer.User.LastName = View.LastName;
            if (!string.IsNullOrEmpty(View.Password))
            {
                if (View.Password != View.PasswordConfirmation)
                {
                    MessageService.ThrowMessage(ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM);
                }

                customer.User.Password = View.Password;
            }
            customer.User.Email = View.Email;
            CustomerService.SaveCustomer(customer);
            View.Name = customer.User.FirstNameLastName;
            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }

        public void PrintOrder(int idOrder)
        {
            Order order = OrderService.GetOrder(idOrder);
            OrderService.PrintOrder(order);
        }

        public void Tracking(int orderId)
        {
            Order order = OrderService.GetOrder(orderId);
            string purolatorUrl = string.Format(ParameterService.GetValue(Constant.TRACKING_PUROLATOR), order.TrackingNumber);
            string upsUrl = string.Format(ParameterService.GetValue(Constant.TRACKING_UPS), order.TrackingNumber);
            NavigationService.Redirect(order.ShippingAddress.Country.Code == "CAN" ? purolatorUrl : upsUrl);
        }


        private Address SaveAddress(string country, string city, string postalCode, string way)
        {
            Address address = new Address
            {
                Country = new Country { Id = Convert.ToInt32(country) },
                City = new City { Code = city, Description = city },
                Way = way,
                PostalCode = postalCode
            };

            return AddressService.SaveNewAddress(address);
        }

        public void SaveAddress()
        {
            if (!CustomerService.AuthenticateCustomer.Enterprise.IsBillingAddressFixed)
            {
                if (!String.IsNullOrEmpty(View.BillingWay))
                {

                    if (CustomerService.AuthenticateCustomer.BillingAddress.Country != null)
                    {
                        Address address = CustomerService.AuthenticateCustomer.BillingAddress;
                        address.Country.Id = Convert.ToInt32(View.BillingCountry);

                        City city = DAOCity.FindCity(View.BillingCity);
                        if (city == null)
                        {
                            address.City = new City { Code = View.BillingCity, Description = View.BillingCity };
                        }

                        address.PostalCode = View.BillingPostalCode;
                        address.Way = View.BillingWay;
                        AddressService.SaveAddress(address);
                    }
                    else
                    {
                        Address address = SaveAddress(View.BillingCountry, View.BillingCity, View.BillingPostalCode,
                                                      View.BillingWay);
                        Customer customer = CustomerService.AuthenticateCustomer;
                        customer.BillingAddress = address;
                        CustomerService.SaveCustomer(customer);
                    }
                }

            }
            if (!CustomerService.AuthenticateCustomer.Enterprise.IsShippingAddressFixed)
            {
                if (!String.IsNullOrEmpty(View.ShippingWay))
                {


                    if (CustomerService.AuthenticateCustomer.ShippingAddress.Country != null)
                    {
                        Address address = CustomerService.AuthenticateCustomer.ShippingAddress;
                        address.Country.Id = Convert.ToInt32(View.ShippingCountry);

                        City city = DAOCity.FindCity(View.ShippingCity);
                        if (city == null)
                        {
                            address.City = new City { Code = View.ShippingCity, Description = View.ShippingCity };
                        }

                        address.PostalCode = View.ShippingPostalCode;
                        address.Way = View.ShippingWay;
                        AddressService.SaveAddress(address);
                    }
                    else
                    {
                        Address address = SaveAddress(View.ShippingCountry, View.ShippingCity, View.ShippingPostalCode,
                                                       View.ShippingWay);
                        Customer customer = CustomerService.AuthenticateCustomer;
                        customer.ShippingAddress = address;
                        CustomerService.SaveCustomer(customer);
                    }

                }

            }

            MessageService.ThrowMessage(Common.ErrorCode.ADM_SAVE_IS_CORRECT);
        }

        public void GenerateSalesByMonthReport()
        {

            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.SalesByMonth.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = CustomerService.AuthenticateCustomer.Enterprise;
            IList<SalesByMonthReportLine> salesReportLines = OrderService.GetSalesByMonthReportLine(enterprise, View.DateStartSalesByMonthReport,
                                                                                      View.DateEndSalesByMonthReport);

            reportParameter.AddDatasource("dsSalesByMonthReport", salesReportLines);
            ReportService.SaveReport("SalesByMonth.pdf", ReportService.GetReport(reportParameter));
        }

        public void GenerateSalesByOrderInformationReport()
        {
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            ReportParameter reportParameter = new ReportParameter
            {
                Assembly = "ATMTECH.ShoppingCart.Services",
                PathToReportAssembly = "ATMTECH.ShoppingCart.Services.Reports.SalesByOrderInformation.rdlc",

                ReportFormat = ReportFormat.PDF,
                Parameters = dictionnaire
            };

            Enterprise enterprise = CustomerService.AuthenticateCustomer.Enterprise;

            IList<SalesByOrderInformationReportLine> salesReportLines = OrderService.GetSalesByOrderInformationReportLine(enterprise, View.DateStartSalesByOrderInformationReport,
                                                                                      View.DateEndSalesByOrderInformationReport);

            reportParameter.AddDatasource("dsSalesByInformationOrder", salesReportLines);
            ReportService.SaveReport("SalesByOrderInformation.pdf", ReportService.GetReport(reportParameter));
        }
    }
}
