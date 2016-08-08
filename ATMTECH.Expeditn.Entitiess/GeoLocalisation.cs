using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class GeoLocalisation : BaseEntity
    {
        public const string LATITUDE = "Latitude";
        public const string LONGITUDE = "Longitude";
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Region { get; set; }
        public Pays Pays { get; set; }
        public string Ville { get; set; }
    }
}
