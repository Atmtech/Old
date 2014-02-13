using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Tests.Builder
{
    public static class StockBuilder
    {
        public static Stock Create()
        {
            return new Stock() { Id = 1 };
        }
        public static Stock CreateValid()
        {
            Stock stock = Create().WithProduct(ProductBuilder.CreateValid()).WithInitialState(10).WithFeature("Red");
            return stock;
        }
        public static Stock WithProduct(this Stock stock, Product product)
        {
            stock.Product = product;
            return stock;
        }
        public static Stock WithInitialState(this Stock stock, int initialState)
        {
            stock.InitialState = initialState;
            return stock;
        }
        public static Stock WithFeature(this Stock stock, string feature)
        {
            stock.Feature = feature;
            return stock;
        }
        public static Stock WithId(this Stock stock, int id)
        {
            stock.Id = id;
            return stock;
        }
    }
}
