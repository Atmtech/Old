using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class NourritureMontant : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public Expedition Expedition { get; set; }
        public Participant Participant { get; set; }
        public decimal MontantInvesti { get; set; }
        public decimal MontantTotalAPayer { get; set; }
        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} - {1} - {2}", Expedition.Nom, Participant.Utilisateur.FirstNameLastName, MontantInvesti); }
        }
    }
}
