using System;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class OrderStatus
    {
        public static int IsWishList { get { return 1; } }
        public static int IsOrdered { get { return 2; } }
        public static int IsShipped { get { return 3; } }
    }
}
