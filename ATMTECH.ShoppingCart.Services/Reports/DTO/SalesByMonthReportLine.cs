using System;

namespace ATMTECH.ShoppingCart.Services.Reports.DTO
{
    public class SalesByMonthReportLine
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Product { get; set; }
        public string Enterprise { get; set; }
        public int JanuarySales { get; set; }
        public int FebruarySales { get; set; }
        public int MarchSales { get; set; }
        public int MaySales { get; set; }
        public int AprilSales { get; set; }
        public int JuneSales { get; set; }
        public int JulySales { get; set; }
        public int AugustSales { get; set; }
        public int SeptemberSales { get; set; }
        public int OctoberSales { get; set; }
        public int NovemberSales { get; set; }
        public int DecemberSales { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal GrandTotalSales { get; set; }
        public decimal TotalValueStockInitialState { get; set; }
        public decimal TotalValueStockActualState { get; set; }
        public int StockActualState { get; set; }
        public int StockInitialState { get; set; }
        public decimal SumGrandTotal { get; set; }
        public decimal SumSubTotal { get; set; }
        public decimal SumTaxes { get; set; }
        public int MinimumAccept { get; set; }
    }
}
