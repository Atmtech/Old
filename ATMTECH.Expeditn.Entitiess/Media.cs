using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Media : BaseEntity
    {
        public Expedition Expedition { get; set; }
        public Etape Etape { get; set; }
        public File Fichier { get; set; }
        public bool EstFichierPrincipaleExpedition { get; set; }
        public bool EstFichierPrincipaleEtape { get; set; }
        public bool EstPrive { get; set; }
    }
}