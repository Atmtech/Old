using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class SiteSpecies : BaseEntity
    {
        public const  string SITE = "Site";

        public Site Site { get; set; }
        public Species Species { get; set; }
        public IList<SiteSpeciesCoordinate> Area { get; set; }
        public int WeightModifier { get; set; }
     }
}
