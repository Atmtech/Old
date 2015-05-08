using System.CodeDom;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Vehicule : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public const string UTILISATEUR = "Utilisateur";

        public Expedition Expedition { get; set; }
        public User Utilisateur { get; set; }
        public string Nom { get; set; }
        public decimal LitreAu100 { get; set; }
        public decimal GallonAuMille { get; set; }
    }
}