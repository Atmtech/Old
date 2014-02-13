using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class OrderLineBuilder
    {
        public static OrderLine Create()
        {
            return new OrderLine() { Id = 1 };
        }
        public static OrderLine CreateValid()
        {
            return Create().WithOrder(OrderBuilder.CreateValid()).WithQuantity(10).WithStock(StockBuilder.CreateValid()).WithActive(true);
        }
        public static OrderLine WithOrder(this OrderLine orderLine, Order order)
        {
            orderLine.Order = order;
            return orderLine;
        }



        public static OrderLine WithActive(this OrderLine orderLine, bool result)
        {
            orderLine.IsActive = result;
            return orderLine;
        }
        public static OrderLine WithQuantity(this OrderLine orderLine, int quantity)
        {
            orderLine.Quantity = quantity;
            orderLine.SubTotal = orderLine.UnitPrice * orderLine.Quantity;
            return orderLine;
        }
        public static OrderLine WithStock(this OrderLine orderLine, Stock stock)
        {
            orderLine.Stock = stock;
            return orderLine;
        }

        public static OrderLine WithId(this OrderLine orderLine, int id)
        {
            orderLine.Id = id;
            return orderLine;
        }

        public static OrderLine WithUnitPrice(this OrderLine orderLine, decimal unitPrice)
        {
            orderLine.UnitPrice = unitPrice;
            orderLine.SubTotal = orderLine.UnitPrice * orderLine.Quantity;
            return orderLine;
        }

    }
}
