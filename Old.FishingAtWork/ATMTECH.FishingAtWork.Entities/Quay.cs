using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Quay : BaseEntity
    {
        public Site Site { get; set; }
        public string Name { get; set; }
    }
}
