using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Etape : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public Expedition Expedition { get; set; }
        public string Nom { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int Distance { get; set; }
        public decimal PrixDuGazAuLitre { get; set; }
        public decimal PrixDuGazAuGallon { get; set; }
        public string Pays { get; set; }
        public string Region { get; set; }
        public string FichierPrincipal
        {
            get
            {
                return Media != null ? Media.FirstOrDefault(x => x.EstFichierPrincipaleEtape).Fichier.FileName : "AucuneImage.png";
            }
        }
        public IList<Media> Media { get; set; }
        public IList<Materiel> Materiel { get; set; }
        public bool EstMesureMetrique { get; set; }
    }
}