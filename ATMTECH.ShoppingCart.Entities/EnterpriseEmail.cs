using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class EnterpriseEmail : BaseEntity
    {
        public const string ENTERPRISE = "Enterprise";

        public Enterprise Enterprise { get; set; }
        public string Email { get; set; }
    }
}
