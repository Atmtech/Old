using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
    public class ParticipantExpedition : BaseEntity 
    {
        public Participant Participant { get; set; }
        public Expedition Expedition { get; set; }
        public decimal MontantGaz { get; set; }
        public decimal MontantPropane { get; set; }
        public decimal MontantBateau { get; set; }
        public decimal MontantNourriture { get; set; }
        public decimal MontantAutre { get; set; }
    }
}
