using System;
using System.Collections.Generic;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.Views.Interface;

namespace ATMTECH.ShoppingCart.Views.Interface
{
    public interface ICustomerInformationPresenter : IViewBase
    {
        string Name { get; set; }
        string Login { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string PasswordConfirmation { get; set; }
        IList<Order> OrdersOrdered { set; }
        IList<Order> OrdersShipped { set; }
        IList<Country> Countrys { set; }

        bool IsSuperUser { get; set; }

        bool IsChangeAddressShippingPossible { set; }
        bool IsChangeAddressBillingPossible { set; }
        bool IsDontAddPersonnalAddress { set; }
        
        string BillingWay { get; set; }
        string BillingCountry { get; set; }
        string BillingCity { get; set; }
        string BillingPostalCode { get; set; }

        string ShippingWay { get; set; }
        string ShippingCountry { get; set; }
        string ShippingCity { get; set; }
        string ShippingPostalCode { get; set; }

        DateTime DateStartSalesByMonthReport { get; }
        DateTime DateEndSalesByMonthReport { get; }

        DateTime DateStartSalesByOrderInformationReport { get; }
        DateTime DateEndSalesByOrderInformationReport { get; }
    }
}
