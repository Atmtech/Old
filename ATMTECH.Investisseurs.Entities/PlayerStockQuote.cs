using ATMTECH.Entities;

namespace ATMTECH.Investisseurs.Entities
{
    public class PlayerStockQuote : BaseEntity
    {
        public const string PLAYER = "Player";
        public const string SYMBOL = "Symbol";

        public Player Player { get; set; }
        public int Quantity { get; set; }
        public string Symbol { get; set; }
    }
}
