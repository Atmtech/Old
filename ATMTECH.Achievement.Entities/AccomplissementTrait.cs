using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class AccomplissementTrait : BaseEntity
    {
        public const string ACCOMPLISSEMENT = "Accomplissement";

        public Accomplissement Accomplissement { get; set; }
        public Trait Trait { get; set; }
        public int ValeurMultiplicative { get; set; }
        public int NombreVoteFavorable { get; set; }
        public int NombreVoteDefavorable { get; set; }
    }
}

