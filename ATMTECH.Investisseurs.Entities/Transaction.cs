using System;
using ATMTECH.Entities;

namespace ATMTECH.Investisseurs.Entities
{
    public class Transaction : BaseEntity
    {
        public const string PLAYER = "Player";
        public Player Player { get; set; }
        public double Amount { get; set; }
        public double TransactionFee { get; set; }
        public int Quantity { get; set; }
        public string StockQuoteSymbol { get; set; }
    }
}
