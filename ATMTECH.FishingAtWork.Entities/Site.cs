using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Site : BaseEntity
    {
        public const string NAME = "Name";
        
        public string Name { get; set; }
        public string Image { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public EnumSiteType Type { get; set; }
        public Temperature CurrentTemperature { get; set; }
        public IList<Waypoint> Waypoints { get; set; }
        public IList<Quay> Quays { get; set; }
        public IList<SiteSpecies> SiteSpecies { get; set; }
        public bool IsTournament { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }
        public int MaxDeep { get; set; }
    }
}
