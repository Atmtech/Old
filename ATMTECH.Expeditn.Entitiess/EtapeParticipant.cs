using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class EtapeParticipant : BaseEntity
    {
        public const string ETAPE = "Etape";
        public Etape Etape { get; set; }
        public Participant Participant { get; set; }
        public decimal Montant { get; set; }
        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} ({1})", Etape.Nom, Participant.Utilisateur.FirstNameLastName); }
        }
    }
}
