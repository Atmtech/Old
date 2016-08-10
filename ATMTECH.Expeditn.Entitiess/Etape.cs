using System;
using System.Collections.Generic;
using ATMTECH.Entities;

namespace ATMTECH.Expeditn.Entities
{
    public class Etape : BaseEntity
    {
        public const string EXPEDITION = "Expedition";
        public Expedition Expedition { get; set; }
        public string Nom { get; set; }
        public Vehicule Vehicule { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public int Distance { get; set; }
        public IList<EtapeParticipant> EtapeParticipant { get; set; }


      //  public GeoLocalisation GeoLocalisation { get; set; }

        //public IList<Media> Media { get; set; }
        //public IList<Materiel> Materiel { get; set; }
        

        public string NombreParticipant
        {
            get
            {
                if (EtapeParticipant != null)
                {
                    return EtapeParticipant.Count.ToString();
                }
                return "0";
            }
        }


        public string ComboboxDescriptionUpdate
        {
            get { return string.Format("{0}", Nom); }
        }
    }
}