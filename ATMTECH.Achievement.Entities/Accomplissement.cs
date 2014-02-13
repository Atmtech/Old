using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Achievement.Entities
{
    public class Accomplissement : BaseEntity
    {
        public const string CATEGORIE = "Categorie";

        public File Image { get; set; }
        public User ProposePar { get; set; }
        public Categorie Categorie { get; set; }
        public int NombreVote { get; set; }
        public int NombreVoteRequis { get; set; }
        public string Couleur { get; set; }
        public string Titre { get; set; }
        public bool EstPrive { get; set; }

        public IList<AccomplissementTrait> AccomplissementTraits { get; set; }
    }

}
