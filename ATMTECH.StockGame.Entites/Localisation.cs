using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.StockGame.Entites
{
    public class Localisation : Entite
    {

        [BsonElement("Ip")]
        public string Ip { get; set; }
        [BsonElement("DateCreation")]
        public DateTime DateCreation { get; set; }
        [BsonElement("Pays")]
        public string Pays { get; set; }
        [BsonElement("Region")]
        public string Region { get; set; }
        [BsonElement("Ville")]
        public string Ville { get; set; }
        [BsonElement("CodePostal")]
        public string CodePostal { get; set; }
    }


}