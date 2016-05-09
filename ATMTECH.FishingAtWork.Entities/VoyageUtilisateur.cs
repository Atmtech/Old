using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class VoyageUtilisateur : BaseEntity
    {
        public Utilisateur Utilisateur { get; set; }
        public Voyage Voyage { get; set; }
    }
}
