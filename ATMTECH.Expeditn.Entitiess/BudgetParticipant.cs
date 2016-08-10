using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class BudgetParticipant : BaseEntity
    {
        public Participant Participant { get; set; }
        public Decimal Montant { get; set; }
        public string Type { get; set; }
    }
}
