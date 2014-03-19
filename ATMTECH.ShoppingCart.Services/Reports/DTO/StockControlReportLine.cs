namespace ATMTECH.ShoppingCart.Services.Reports.DTO
{
    public class StockControlReportLine
    {
        public string Order { get; set; }
        public string Stock { get; set; }
        public string OrderLineQuantity { get; set; }
        public string StockTransactionQuantity { get; set; }
        public string Problem { get; set; }
    }
}
