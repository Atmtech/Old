using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
    public class SuiviPrix : Entite
    {
        [BsonElement("Nom")]
        public string Nom { get; set; }

        [BsonElement("Utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [BsonElement("Debut")]
        public DateTime Debut { get; set; }


        [BsonElement("UrlSuiviPrix")]
        public string UrlSuiviPrix { get; set; }

        [BsonElement("TypeSuiviPrix")]
        public string TypeSuiviPrix { get; set; }
    }
}
