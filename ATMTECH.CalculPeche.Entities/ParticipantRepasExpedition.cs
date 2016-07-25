using System;
using ATMTECH.Entities;

namespace ATMTECH.CalculPeche.Entities
{
    public class ParticipantRepasExpedition : BaseEntity 
    {
        public const string EXPEDITION = "Expedition";
       public Participant Participant { get; set; }
       public Expedition Expedition { get; set; }
       public DateTime DateParticipation { get; set; }
       public int NombreRepas { get; set; }
       public string NomParticipant { get { return Participant.Nom; } }
       public string NomExpedition { get { return Expedition.Nom; } }
    }
}
