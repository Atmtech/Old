using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class StockTemplate : BaseEntity
    {
        public const string GROUP = "Group";

        public string Group { get; set; }
        
    }
}
