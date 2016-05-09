using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class SpeciesLure : BaseEntity
    {
        public const string SPECIES = "Species";

        public Species Species { get; set; }
        public Lure Lure { get; set; }
        public int AttractingPercentage { get; set; }
    }
}
