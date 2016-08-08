using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Media : BaseEntity
    {
        public Expedition Expedition { get; set; }
        public Etape Etape { get; set; }
        public File Fichier { get; set; }
        public bool EstFichierPrincipal { get; set; }
        public bool EstPrive { get; set; }
    }
}