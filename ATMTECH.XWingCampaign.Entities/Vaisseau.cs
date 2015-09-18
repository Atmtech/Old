using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.XWingCampaign.Entities
{
    public class Vaisseau: BaseEntity
    {
        public const string NOM = "Nom";

        public string Nom { get; set; }
        public int Attaque { get; set; }
        public int Defense { get; set; }
        public int Coque { get; set; }
        public int Bouclier { get; set; }

        public IList<IntelligenceArtificiel> ListeMouvement { get; set; }
    }
}
