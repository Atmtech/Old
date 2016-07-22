using System;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
    public class MontantDu : BaseEntity
    {
        public Participant ParticipantPayeur { get; set; }
        public Participant ParticipantPaye { get; set; }
        public double Montant { get; set; }
    }
}
