using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class CoordinateTry : BaseEntity
    {
        public const string SITE = "Site";
        public Site Site { get; set; }
        public Species Species { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string ColorName { get; set; }

    }
}
