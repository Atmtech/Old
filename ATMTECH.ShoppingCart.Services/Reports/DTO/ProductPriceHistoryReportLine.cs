using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMTECH.ShoppingCart.Services.Reports.DTO
{
    public class ProductPriceHistoryReportLine
    {
        public string Product { get; set; }
        public decimal PriceBefore  { get; set; }
        public decimal PriceAfter { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
