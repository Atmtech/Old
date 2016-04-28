using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class SiteSpeciesCoordinate : BaseEntity
    {
        public const string SITE = "Site";
        public const string SPECIES = "Species";

        public Site Site { get; set; }
        public Species Species { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}
