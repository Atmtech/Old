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
        public Vehicule Vehicule { get; set; }
        public string Nom { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public int Distance { get; set; }
        public decimal PrixDuCarburantAuLitre { get; set; }
        public GeoLocalisation GeoLocalisation { get; set; }
        
        public string FichierPrincipal
        {
            get
            {
                return Media != null
                    ? Media.FirstOrDefault(x => x.EstFichierPrincipal).Fichier.FileName
                    : "AucuneImage.png";
            }
        }

        public IList<Media> Media { get; set; }
        public IList<Materiel> Materiel { get; set; }
        public IList<EtapeParticipant> EtapeParticipant { get; set; }
    }
}