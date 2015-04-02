using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Coupon : BaseEntity
    {
        public const string IDENT = "Ident";
        public const string DATE_EXPIRED = "DateExpired";

        public string Ident { get; set; }
        public decimal PercentageSave { get; set; }
        public bool IsShippingSave { get; set; }
        public DateTime DateExpired { get; set; }
        public string ComboboxDescriptionUpdate { get { return Ident + "-" + PercentageSave + " " + IsShippingSave.ToString(); } }
    }
}
