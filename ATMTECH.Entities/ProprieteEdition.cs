using System;

namespace ATMTECH.Entities
{
    [Serializable]
    public class ProprieteEdition : BaseEntity
    {
        public string NomEntite { get; set; }
        public string NomPropriete { get; set; }
        public string Affichage { get; set; }
        public bool EstAffiche { get; set; }
    }
}
