using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Temperature : BaseEntity
    {
        public int Degree { get; set; }
        public EnumTemperatureType Type { get; set; }
    }
}
