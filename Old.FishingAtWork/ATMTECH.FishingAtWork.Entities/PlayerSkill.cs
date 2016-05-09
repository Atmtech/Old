using ATMTECH.Entities;


namespace ATMTECH.FishingAtWork.Entities
{
    public class PlayerSkill : BaseEntity
    {
        public const string PLAYER = "Player";

        public Player Player { get; set; }
        public EnumSkill Skill { get; set; }
        public int SkillValue { get; set; }
    }
}
