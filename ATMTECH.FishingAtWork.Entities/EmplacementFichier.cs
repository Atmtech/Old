using ATMTECH.Entities;

namespace ATMTECH.FishingAtWork.Entities
{
    public class EmplacementFichier : BaseEntity
    {
        public Emplacement Emplacement { get; set; }
        public Fichier Fichier { get; set; }
    }
}
