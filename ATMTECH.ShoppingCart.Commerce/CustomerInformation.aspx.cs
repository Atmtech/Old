using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class CustomerInformation : PageBaseShoppingCart<CustomerInformationPresenter, ICustomerInformationPresenter>, ICustomerInformationPresenter
    {

        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public IList<Order> OrdersOrdered { set; private get; }
        public IList<Order> OrdersShipped { set; private get; }
        public IList<Country> Countrys { set; private get; }
        public bool IsSuperUser { get; set; }
        public bool IsChangeAddressShippingPossible { set; private get; }
        public bool IsChangeAddressBillingPossible { set; private get; }
        public bool IsDontAddPersonnalAddressShipping { set; private get; }
        public bool IsDontAddPersonnalAddressBilling { set; private get; }
        public string BillingWay { get; set; }
        public string BillingCountry { get; set; }
        public string BillingCity { get; set; }
        public string BillingPostalCode { get; set; }
        public string ShippingWay { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPostalCode { get; set; }
        public DateTime DateStartSalesByMonthReport { get; private set; }
        public DateTime DateEndSalesByMonthReport { get; private set; }
        public DateTime DateStartSalesByOrderInformationReport { get; private set; }
        public DateTime DateEndSalesByOrderInformationReport { get; private set; }
    }
}