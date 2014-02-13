using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class PlayerEquipment : BaseEntity
    {
     
        public const string PLAYER = "Player";

        public Player Player { get; set; }
        public Equipement Equipment { get; set; }
        public EnumStatusEquipment Status { get; set; }
    }
}
