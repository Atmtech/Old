using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class PlayerAchievement : BaseEntity
    {
        public const string PLAYER = "Player";

        public Player Player { get; set; }
        public EnumAchievement Achievement { get; set; }
    }
}
