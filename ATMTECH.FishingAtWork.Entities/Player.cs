using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{

    public partial class Player : BaseEntity
    {
        public const string EXPERIENCE = "Experience";

        public double Money { get; set; }
        public int Experience { get; set; }
        public string Image { get; set; }
        public int MaximumWaypoint { get; set; }
        public Trip CurrentTrip { get; set; }
        public IList<PlayerSkill> Skills { get; set; }
        public IList<PlayerAchievement> Achievements { get; set; }
        public IList<PlayerEquipment> Equipements { get; set; }
        public User User { get; set; }
    }
}
