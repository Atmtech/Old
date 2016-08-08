using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Participant : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public const string EST_ADMINISTRATEUR = "EstAdministrateurExpedition";

        public Expedition Expedition { get; set; }
        public User Utilisateur { get; set; }
        public bool EstAdministrateur { get; set; }
    }
}