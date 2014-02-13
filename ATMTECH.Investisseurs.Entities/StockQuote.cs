using System;
using ATMTECH.Entities;

namespace ATMTECH.Investisseurs.Entities
{
    public class StockQuote : BaseEntity
    {
        public string Symbol { get; set; }
        public double Last { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Change { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public int Volume { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
    }
}
