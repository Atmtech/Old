using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class MailingList : BaseEnumeration
    {
        public string Email { get; set; }
        public string ComboboxDescriptionUpdate { get { return Email; } }
    }
}
