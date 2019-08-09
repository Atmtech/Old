using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
  public  class HistoriqueSuiviPrix : Entite
    {
        [BsonElement("Id")]
        public string IdHotel { get; set; }

        [BsonElement("DateSuiviPrix")]
        public DateTime DateSuiviPrix { get; set; }

        [BsonElement("SuiviPrix")]
        public SuiviPrix SuiviPrix { get; set; }
        
        [BsonElement("TypeSuiviPrix")]
        public string TypeSuiviPrix { get; set; }

       
        [BsonElement("Hotel")]
        public string Hotel { get; set; }

        [BsonElement("Prix")]
        public decimal Prix { get; set; }

        [BsonElement("CompagnieAviation")]
        public string CompagnieAviation { get; set; }

        [BsonElement("DateDepart")]
        public DateTime DateDepart { get; set; }

        [BsonElement("DateRetour")]
        public DateTime DateRetour { get; set; }


        [BsonElement("VilleDepart")]
        public string VilleDepart { get; set; }

        [BsonElement("VilleArrive")]
        public string VilleArrive { get; set; }

        [BsonElement("PlanRepas")]
        public string PlanRepas { get; set; }

        [BsonElement("NombreTotalAppreciation")]
        public string NombreTotalAppreciation { get; set; }

        [BsonElement("CoteTotalAppreciation")]
        public string CoteTotalAppreciation { get; set; }

        [BsonElement("OperateurEnChargeDuVoyage")]
        public string OperateurEnChargeDuVoyage { get; set; }

        [BsonElement("NombreEtoile")]
        public string NombreEtoile { get; set; }

        [BsonElement("LienHotel")]
        public string LienHotel { get; set; }


    }
}
