using ATMTECH.Entities;

namespace ATMTECH.Vachier.Entities
{
    public class Vachier : BaseEntity
    {
        public const string JAIME_TA_MERDE = "JaimeTaMerde";
        public Insulte Insulte { get; set; }
        public int JaimeTaMerde { get; set; }
        public string Ip { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
    }
}
