using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Lure : BaseEntity
    {
        public const string NAME = "Name";
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public EnumLureType Type { get; set; }
    }
}
