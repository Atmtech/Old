using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Etape : BaseEntity
    {
        public Expedition Expedition { get; set; }
        public string Nom { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public IList<Media> Media { get; set; }
        public IList<Materiel> Materiel { get; set; }
    }
}