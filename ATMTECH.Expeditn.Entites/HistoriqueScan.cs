using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
  public  class HistoriqueScan : Entite
    {
        [BsonElement("DateScan")]
        public DateTime DateScan { get; set; }

        [BsonElement("PlanificationScan")]
        public PlanificationScan PlanificationScan { get; set; }
        
        [BsonElement("TypeScan")]
        public string TypeScan { get; set; }

       
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

    }
}
