using System;
using System.ComponentModel;
using ATMTECH.Entities;

namespace ATMTECH.Mediator.Entities
{
    public class Clavardage: BaseEntity
    {
        public const string NO_CLAVARDAGE = "NoClavardage";
        public const string TYPE = "Type";

        [Category("UniqueKey")]
        public int NoClavardage { get; set; }
        public string Type { get; set; }
        public string Texte { get; set; }
        public int NoUtilisateur { get; set; }
        public string Forums { get; set; }
        public DateTime Date { get; set; }
        public Utilisateur Utilisateur { get; set; }
    }
}
