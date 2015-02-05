using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Views;
using ATMTECH.ShoppingCart.Views.Interface;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class Basket : PageBaseShoppingCart<BasketPresenter, IBasketPresenter>, IBasketPresenter
    {
        public Order CurrentOrder { get; set; }
        public bool IsOrderFinalized { set; private get; }
        public bool IsShippingNotIncluded { set; private get; }
        public bool IsShippingManaged { set; private get; }
        public IList<Address> ShippingAddress { set; private get; }
        public IList<Address> BillingAddress { set; private get; }
        public bool IsPaypal { set; private get; }
        public string AskShippingLabel { set; private get; }
        public IList<EnumOrderInformation> EnumOrderInformation1 { set; private get; }
        public IList<EnumOrderInformation> EnumOrderInformation2 { set; private get; }
        public bool IsAskShipping { set; private get; }
        public bool IsOrderLocked { set; private get; }
        public string Project { get; set; }
        public decimal ShippingTotal { set; private get; }
        public decimal ShippingWeight { set; private get; }
        public void RefreshOrderDisplay(Order value)
        {
            throw new NotImplementedException();
        }

        public bool IsBillingAddressFixed { set; private get; }
        public bool IsShippingAddressFixed { set; private get; }
        public int ShippingAddressSelected { get; private set; }
        public int BillingAddressSelected { get; private set; }
        public bool IsPaypalRequired { set; private get; }
        public bool IsManageOrderInformation1 { set; private get; }
        public bool IsManageOrderInformation2 { set; private get; }
        public string OrderInformation1Value { get; private set; }
        public string OrderInformation2Value { get; private set; }
        public bool IsDontAddPersonnalAddressShipping { set; private get; }
        public bool IsDontAddPersonnalAddressBilling { set; private get; }
        public string NoAddressFound { set; private get; }
    }
}