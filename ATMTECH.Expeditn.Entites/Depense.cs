using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
    public class Depense : Entite
    {
        [BsonElement("Utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [BsonElement("Montant")]
        public string Montant { get; set; }

        [BsonElement("TypeActivite")]
        public string TypeActivite { get; set; }
     
    }


}