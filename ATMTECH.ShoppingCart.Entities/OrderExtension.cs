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
            get
            {
                if (Customer != null)
                {
                    return Customer.User != null ? Customer.User.FirstNameLastName : "";
                }
                return "";
            }
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

        public string OrderDetail
        {
            get
            {
                string html = "<br><table style='width:100%;'>";
                html += "<tr><td style='font-weight: bold;border-bottom:solid 1px gray;'>{LangueProduit}</td><td style='font-weight: bold;border-bottom:solid 1px gray;'>{LangueQuantite}</td><td style='font-weight: bold;border-bottom:solid 1px gray;'>{LangueSousTotal}</td></tr>";

                foreach (OrderLine orderLine in OrderLines)
                {
                    html += string.Format("<tr><td>{0}</td><td style='text-align:center;'>{1}</td><td>{2}</td></tr>", orderLine.ProductDescription, orderLine.Quantity, orderLine.SubTotal.ToString("C"));
                }

                html += "</table>";
                html += "<br>";
                html += "<br>";
                html += "<table style='width:400px;'>";
                html += string.Format("<tr><td style='font-weight: bold;'>TPS</td><td>{0}</td></tr>", CountryTax.ToString("C"));
                html += string.Format("<tr><td style='font-weight: bold;border-bottom:solid 1px gray;'>TVQ</td><td style='font-weight: bold;border-bottom:solid 1px gray;'>{0}</td></tr>", RegionalTax.ToString("C"));
                html += string.Format("<tr><td style='font-weight: bold;border-bottom:double 1px gray;'>Total</td><td style='font-weight: bold;border-bottom:double 1px gray;'>{0}</td></tr>", GrandTotal.ToString("C"));
                html += "</table>";
                return html;
            }
        }
    }
}
