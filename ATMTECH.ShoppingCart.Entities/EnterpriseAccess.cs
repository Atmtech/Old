using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class EnterpriseAccess : BaseEntity
    {
        public Enterprise Enterprise { get; set; }
        public User User { get; set; }
    }
}
