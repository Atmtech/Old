using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class NourritureExpedition
    {
        public const string EXPEDITION = "Expedition";
        public Expedition Expedition { get; set; }
        public Nourriture Nourriture { get; set; }
        public User Utilisateur { get; set; }
        public DateTime Date { get; set; }

        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0} {2} ({1})", Expedition.Nom, Utilisateur.FirstNameLastName, Nourriture.Nom); }
        }

    }
}
