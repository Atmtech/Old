using System;
using System.Collections.Generic;
using System.Linq;
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
        public Participant Chef
        {
            get
            {
                return Participant != null ? Participant.FirstOrDefault(x => x.EstAdministrateurExpedition) : null;
            }
        }
        public int NombreParticipant
        {
            get
            {
                return Participant != null ? Participant.Count(x => x.EstDansExpedition) : 0;
            }
        }
        public int NombreParticipantQuiSuive
        {
            get
            {
                return Participant != null ? Participant.Count(x => x.EstDansExpedition == false) : 0;
            }
        }
        public string FichierPrincipal
        {
            get
            {
                return Media != null ? Media.FirstOrDefault(x => x.EstFichierPrincipaleExpedition).Fichier.FileName : "AucuneImage.png";

            }
        }
        public IList<Participant> Participant { get; set; }
        public IList<Materiel> Materiel { get; set; }
        public IList<Media> Media { get; set; }
        public IList<Etape> Etape { get; set; } 
        public Categorie Categorie { get; set; }
        public bool EstPrive { get; set; }
    }
}