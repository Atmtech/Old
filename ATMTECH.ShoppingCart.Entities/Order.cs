using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public partial class Order : BaseEntity
    {
        public const string CUSTOMER = "Customer";
        public const string ORDER_STATUS = "OrderStatus";
        public const string ENTERPRISE = "Enterprise";
        public const string SHIPPING_DATE = "ShippingDate";
        public const string FINALIZED_DATE = "FinalizedDate";

        public string OrderInformation1 { get; set; }
        public string OrderInformation2 { get; set; }

        public Enterprise Enterprise { get; set; }
        public Decimal GrandTotal { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal ShippingTotal { get; set; }
        public Decimal CountryTax { get; set; }
        public Decimal RegionalTax { get; set; }
        public Customer Customer { get; set; }
        public IList<OrderLine> OrderLines { get; set; }
        public int OrderStatus { get; set; }

        public DateTime? ShippingDate { get; set; }
        public DateTime? FinalizedDate { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public string ShippingAttention { get; set; }
        public string TrackingNumber { get; set; }
        public string Project { get; set; }
        public string ToAttention { get; set; }
        public string EnterpriseAttention { get; set; }
        public Decimal TotalWeight { get; set; }
        public bool IsPayPal { get; set; }
        public bool IsMailConfirmingOrderSent { get; set; }
        public bool IsAskShipping { get; set; }
        public bool IsOrderLocked { get; set; }
        public Coupon Coupon { get; set; }
        public decimal GrandTotalWithCoupon { get; set; }

        public string AddressBilling { get; set; }
        public string AddressShipping { get; set; }
        public string PostalCodeShipping { get; set; }

        public string ComboboxDescriptionUpdate
        {
            get
            {
                if (Customer != null)
                {
                    if (Customer.User != null)
                    {
                        return Id + "-" + Customer.User.FirstNameLastName;
                    }
                }
                return Id.ToString();
            }
        }
    }
}
