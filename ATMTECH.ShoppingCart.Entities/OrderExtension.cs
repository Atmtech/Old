namespace ATMTECH.ShoppingCart.Entities
{
    public partial class Order
    {
        public string BillingAddressDescription
        {
            get { return BillingAddress != null ? BillingAddress.DisplayAddress : ""; }
        }
        public string ShippingAddressDescription
        {
            get { return ShippingAddress != null ? ShippingAddress.DisplayAddress : ""; }
        }

        public string CustomerFullName
        {
            get { return Customer.User != null ? Customer.User.FirstNameLastName : ""; }
        }

        public string EnterpriseName
        {
            get { return Enterprise != null ? Enterprise.Name : ""; }
        }
        public int TotalItemOrderLine
        {
            get
            {
                return OrderLines != null ? OrderLines.Count : 0;
            }
        }
    }
}
