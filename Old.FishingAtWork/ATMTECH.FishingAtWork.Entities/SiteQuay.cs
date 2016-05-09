using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class SiteQuay : BaseEntity
    {
        public const string SITE = "Site";

        public Site Site { get; set; }
        public Quay Quay { get; set; }
    }
}
