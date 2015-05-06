using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Participant : BaseEntity
    {
        public const string EXPEDITION = "Expedition";

        public Expedition Expedition { get; set; }
        public User Utilisateur { get; set; }
        public bool EstDansExpedition { get; set; }
        public bool EstAdministrateurExpedition { get; set; }
    }
}