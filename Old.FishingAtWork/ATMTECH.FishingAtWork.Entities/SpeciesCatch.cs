using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class SpeciesCatch : BaseEntity
    {
        public const string SITE = "Site";

        public Site Site { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Player Player { get; set; }
        public bool IsSuccessfulCatch { get; set; }
        public bool IsSuccessArea { get; set; }
        public Lure Lure { get; set; }
        public Species Species { get; set; }
        public int Experience { get; set; }
        public double Money { get; set; }
        public double Weight { get; set; }
    }
}
