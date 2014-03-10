using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class GroupProduct : BaseEntity
    {
        public const string PRODUCT = "Product";
        public const string GROUP = "Group";

        public Product Product { get; set; }
        public Group Group { get; set; }
        public bool IsRead { get; set; }
        public bool IsOrderable { get; set; }

        public string ComboboxDescriptionUpdate { get { return Product.Name + "-" + Group.Name; } }
    }
}
