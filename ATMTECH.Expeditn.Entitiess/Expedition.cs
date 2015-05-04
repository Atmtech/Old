using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Expedition : BaseEntity
    {
        public string Nom { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Budget { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public IList<Participant> Participant { get; set; }
        public IList<Materiel> Materiel { get; set; }
        public IList<Media> Media { get; set; }
        public Categorie Categorie { get; set; }
        public bool EstPrive { get; set; }
    }
}