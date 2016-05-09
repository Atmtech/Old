using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{

    public partial class Record : BaseEntity
    {
        public const string SPECIES = "Species";

        public Species Species { get; set; }
        public double Weight { get; set; }
        public Site Site { get; set; }
        public Player Player { get; set; }
    }
}
