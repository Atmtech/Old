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

        Address PersonnalShippingAddress { set; }
        Address PersonnalBillingAddress { set; }

        IList<Country> Countrys { set; }

        IList<EnumOrderInformation> EnumOrderInformation1 { set; }
        IList<EnumOrderInformation> EnumOrderInformation2 { set; }

        bool IsPanelModifyShippingAddressOpen { get; set; }
        bool IsPanelModifyBillingAddressOpen { get; set; }
        bool IsAskShipping { set; }
        bool IsOrderLocked { set; }

        string ModifyShippingAddressWay { get; set; }
        int ModifyShippingCountry { get; set; }
        string ModifyShippingCity { get; set; }
        string ModifyShippingPostalCode { get; set; }

        string ModifyBillingAddressWay { get; set; }
        int ModifyBillingCountry { get; set; }
        string ModifyBillingCity { get; set; }
        string ModifyBillingPostalCode { get; set; }

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
    }
}
