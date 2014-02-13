using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class PlayerCatch : BaseEntity
    {
        public const string PLAYER = "Player";
        public const string SITE = "Site";
        public const string SPECIES = "Species";

        public Player Player { get; set; }
        public Site Site { get; set; }
        public int NumberOfCatch { get; set; }
        public Species Species { get; set; }
    }
}
