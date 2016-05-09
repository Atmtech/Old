using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class Utilisateur : BaseEntity
    {
        public const string COURRIEL = "Courriel";
        public const string MOT_PASSE = "MotPasse";

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string MotPasse { get; set; }
        public string Courriel { get; set; }

        public IList<Voyage> Voyages { get; set; } 
    }
}
