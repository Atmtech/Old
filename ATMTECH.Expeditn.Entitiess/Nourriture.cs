using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Nourriture : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public const string UTILISATEUR = "Utilisateur";

        public Expedition Expedition { get; set; }
        public User Utilisateur { get; set; }
        public string Nom { get; set; }
        public DateTime DateTime { get; set; }
    }
}
