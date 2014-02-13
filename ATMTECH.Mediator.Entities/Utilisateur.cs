using System.ComponentModel;
using ATMTECH.Entities;

namespace ATMTECH.Mediator.Entities
{
    public class Utilisateur : BaseEntity
    {
        public const string NO_UTILISATEUR = "NoUtilisateur";

        
        [Category("UniqueKey")]
        public int NoUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }
        public string NomHote { get; set; }
        public bool EstConnecte { get; set; }
        public string EstFlashWindow { get; set; }
        public string NomUtilisateur2 { get; set; }
    }
}
