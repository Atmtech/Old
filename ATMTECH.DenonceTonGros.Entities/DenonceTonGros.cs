using ATMTECH.Entities;

namespace ATMTECH.DenonceTonGros.Entities
{
    public class DenonceTonGrosTas : BaseEntity
    {
        public const string JAIME_TA_MERDE = "Jaime";
        public Insulte Insulte { get; set; }
        public int Jaime { get; set; }
        public string Ip { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
    }
}
