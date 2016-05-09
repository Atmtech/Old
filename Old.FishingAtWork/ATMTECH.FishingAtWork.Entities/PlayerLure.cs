using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class PlayerLure : BaseEntity
    {
     
        public const string PLAYER = "Player";
        public const string LURE = "Lure";

        public Player Player { get; set; }
        public Lure Lure { get; set; }
        public int Quantity { get; set; }
    }
}
