using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class AffichageSommeInvesti
    {
        public User Utilisateur { get; set; }
        public Expedition Expedition { get; set; }
        public decimal MontantEtapeAvion { get; set; }
        public decimal MontantEtapeAutomobile { get; set; }
        public decimal MontantEtapeBateau { get; set; }
        public decimal MontantEtapeTrain { get; set; }
        public decimal MontantNourriture { get; set; }
        public decimal MontantAutre { get; set; }
        public decimal MontantTotal
        {
            get
            {
                return MontantEtapeAvion + MontantEtapeAutomobile + MontantEtapeBateau + MontantNourriture + MontantAutre;
            }
        }
    }
}
