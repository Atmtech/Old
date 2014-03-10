using System;
using ATMTECH.Entities;

namespace ATMTECH.ShoppingCart.Entities
{
    [Serializable]
    public class Address : BaseEntity
    {
        public const string WAY = "Way";
        public const string POSTAL_CODE = "PostalCode";
        public const string COUNTRY = "Country";
        public const string CITY = "City";

        public string WayType { get; set; }
        public string Way { get; set; }
        public string No { get; set; }
        public string PostalCode { get; set; }
        public string PostalCase { get; set; }
        public City City { get; set; }
        public Country Country { get; set; }
        public const string DISPLAY_ADDRESS = "DisplayAddress";

        public string DisplayAddress
        {
            get
            {
                string cityName = string.Empty;
                if (City != null)
                {
                    cityName = City.Description;
                }
                string countryName = string.Empty;
                if (Country != null)
                {
                    countryName = Country.Description;
                }
                return No + " " + WayType + " " + Way + " " + cityName + ", " + countryName + " " + PostalCode;
            }
        }

        public string ComboboxDescriptionUpdate { get { return DisplayAddress; } }

    }
}
