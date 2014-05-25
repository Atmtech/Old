using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface IBasketPresenter : IViewBase
    {
        Order CurrentOrder { get; set; }
        bool IsOrderFinalized { set; }
        bool IsShippingNotIncluded { set; }
        bool IsShippingManaged { set; }
        IList<Address> ShippingAddress { set; }
        IList<Address> BillingAddress { set; }
        bool IsPaypal { set; }
        string AskShippingLabel { set; }
        IList<EnumOrderInformation> EnumOrderInformation1 { set; }
        IList<EnumOrderInformation> EnumOrderInformation2 { set; }
        bool IsAskShipping { set; }
        bool IsOrderLocked { set; }
        string Project { get; set; }
        decimal ShippingTotal { set; }
        decimal ShippingWeight { set; }
        void RefreshOrderDisplay(Order value);
        bool IsBillingAddressFixed { set; }
        bool IsShippingAddressFixed { set; }
        int ShippingAddressSelected { get; }
        int BillingAddressSelected { get; }
        bool IsPaypalRequired { set; }
        bool IsManageOrderInformation1 { set; }
        bool IsManageOrderInformation2 { set; }
        string OrderInformation1Value { get; }
        string OrderInformation2Value { get; }

        bool IsDontAddPersonnalAddressShipping { set; }
        bool IsDontAddPersonnalAddressBilling { set; }

        string NoAddressFound { set; }
    }
}
