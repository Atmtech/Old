using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class LogVisit : BaseEntity
    {
        public string Ip { get; set; }
        public string Page { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
    }
}
