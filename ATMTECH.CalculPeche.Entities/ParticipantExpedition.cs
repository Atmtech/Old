using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
    public class ParticipantExpedition : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public Participant Participant { get; set; }
        public Expedition Expedition { get; set; }
        public double MontantAutomobile { get; set; }
        public double MontantPropane { get; set; }
        public double MontantBateau { get; set; }
        public double MontantNourriture { get; set; }
        
        public double Total
        {
            get
            {
                return  MontantBateau + MontantAutomobile + MontantNourriture + MontantPropane;
            }
        }
    }
}
