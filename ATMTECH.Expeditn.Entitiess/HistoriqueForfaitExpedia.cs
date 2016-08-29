using System;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class HistoriqueForfaitExpedia : BaseEntity
    {
        public const string RECHERCHE_FORFAIT_EXPEDIA = "RechercheForfaitExpedia";


        public RechercheForfaitExpedia RechercheForfaitExpedia { get; set; }
        public string NomHotel { get; set; }
        public string CompagnieOrganisatrice { get; set; }
        public GeoLocalisation GeoLocalisation { get; set; }
        public DateTime DateDepart { get; set; }
        public int NombreJour { get; set; }
        public decimal Prix { get;set; }
        public string NombreEtoile { get; set; }
        public string AppreciationUtilisateur { get; set; }
        public string NombreUtilisateurAppreciation { get; set; }
    }
}
