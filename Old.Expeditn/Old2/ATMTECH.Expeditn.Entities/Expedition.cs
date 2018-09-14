using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Expedition : BaseEntity
    {
        public string Nom { get; set; }
        public DateTime DatePrevuDebut { get; set; }
        public DateTime DatePrevuFin { get; set; }
        public decimal BudgetPrevu { get; set; }
        public decimal BudgetReel { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public IList<Participant> Participant { get; set; }
        public IList<Materiel> Materiel { get; set; }
        public IList<Media> Media { get; set; }
        public bool EstPrive { get; set; }
    }
}