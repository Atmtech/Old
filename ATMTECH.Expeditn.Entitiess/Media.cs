using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Media : BaseEntity
    {
        public Expedition Expedition { get; set; }
        public File Fichier { get; set; }
        public bool EstFichierPrincipale { get; set; }
        public bool EstPrive { get; set; }
    }
}