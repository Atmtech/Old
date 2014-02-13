using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.DTO
{
    public class ProductBySale
    {
        public Product Product { get; set; }
        public int NumberTotalSale { get; set; }
        public decimal TotalSale { get; set; }
    }
}
