using System;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
    public class ParticipantRepasExpedition : BaseEntity 
    {
       public Participant Participant { get; set; }
       public Expedition Expedition { get; set; }
       public DateTime Date { get; set; }
       public int NombreRepas { get; set; }
    }
}
