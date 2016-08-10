using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class NourritureParticipant : BaseEntity
    {
        public const string NOURRITURE = "Nourriture";
        public Nourriture Nourriture { get; set; }
        public Participant Participant { get; set; }
        public decimal Montant { get; set; }
        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} {2} ({1})", Nourriture.Expedition.Nom, Participant.Utilisateur.FirstNameLastName, Nourriture.Nom); }
        }

    }
}
