namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Species
    {
        public int LureCount { get { return  SpeciesLure == null ? 0: SpeciesLure.Count; } }
    }
}
