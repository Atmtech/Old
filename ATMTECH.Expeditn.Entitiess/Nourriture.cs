using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Nourriture : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public Expedition Expedition { get; set; }
        public string Nom { get; set; }
        public string Menu { get; set; }
        public DateTime Date { get; set; }
        public Participant Cuisinier { get; set; }

        public IList<NourritureParticipant> NourritureParticipant { get; set; }

        

        public string NombreParticipant
        {
            get
            {
                if (NourritureParticipant != null)
                {
                    return NourritureParticipant.Count.ToString();
                }
                return "0";
            }
        }


        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} - {1}", Nom, Cuisinier.Utilisateur.FirstNameLastName); }
        }
    }
}
