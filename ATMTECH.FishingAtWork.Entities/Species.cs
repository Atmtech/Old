using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Species : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public EnumSpeciesType SpecieType { get; set; }
        public int MaximumWeight { get; set; }
        public int MinimumWeight { get; set; }
        public int MaximumExperience { get; set; }
        public double MoneyValueInTournament { get; set; }
        public IList<SpeciesLure> SpeciesLure { get; set; }
        public string ColorName { get; set; }
    }
}
