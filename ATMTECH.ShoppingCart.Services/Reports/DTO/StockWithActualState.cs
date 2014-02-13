using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Services.Reports.DTO
{
   public class StockWithActualState
    {
       public Stock Stock { get; set; }
       public int ActualState { get; set; }
       public decimal ActualValue { get; set; }

    }
}
