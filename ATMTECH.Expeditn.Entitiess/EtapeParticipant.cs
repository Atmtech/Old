using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class EtapeParticipant : BaseEntity
    {
        public const string ETAPE = "Etape";
        public Etape Etape { get; set; }
        public User Utilisateur { get; set; }
        public decimal Montant { get; set; }
    }
}
