using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class RechercheForfaitExpedia : BaseEntity
    {
        public User Utilisateur { get; set; }
        public string Nom { get; set; }
        public GeoLocalisation GeoLocalisation { get; set; }
        public string Url { get; set; }
        public DateTime DateDepart { get; set; }
        public int NombreJour { get; set; }
    }
}
