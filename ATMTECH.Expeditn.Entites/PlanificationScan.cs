using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
    public class PlanificationScan : Entite
    {
        [BsonElement("Nom")]
        public string Nom { get; set; }

        [BsonElement("Utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [BsonElement("UrlScan")]
        public string UrlScan { get; set; }

        [BsonElement("TypeScan")]
        public string TypeScan { get; set; }
    }
}
