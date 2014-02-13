using System;
using System.Web.UI;
using ATMTECH.Web.Services;

namespace ATMTECH.ShoppingCart.WebSite
{
    public partial class PaypalTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TestPaypal(object sender, ImageClickEventArgs e)
        {
            PaypalService paypal = new PaypalService();
            paypal.SendPaypalRequest(true, new PaypalDto() { OrderDescription = "OrderDescription", Price = 100, ProductId = "ProductId", ProductName = "ProductName", Quantity = 1 });
        }

        protected void TestUps(object sender, EventArgs e)
        {
            UpsDto upsDto = new UpsDto
                                {
                                       AccessLicenceNumber = "4C351CEF022AC42C",
                                       UserId = "upssagace",
                                       Password = "fra321",
                                       ShipperPostalCode = "G1M3R8",
                                       WeightType = UpsService.WeightType.LBS.ToString(),
                                       Weight = 10,
                                       PackageType = ((int)UpsService.PackageType.Package).ToString(),
                                       ShippingServiceCode = ((int)UpsService.ServiceCode.UpsWorldWidExpedited).ToString(),
                                       ShippingCountryCode = "GB",
                                       ShippingPostalCode = " SW1A 0AA"
                                   };
            UpsService upsService = new UpsService();
            Response.Write(upsService.GetShippingRate(upsDto));
        }
    }
}