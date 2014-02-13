using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class WallPost : BaseEntity
    {
        public Player Player { get; set; }
        public string Post { get; set; }
    }
}
