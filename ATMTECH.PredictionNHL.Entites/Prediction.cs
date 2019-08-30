using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.PredictionNHL.Entites
{
    public class Prediction : Entite
    {
        [BsonElement("GamePrimaryKey")]
        public int GamePrimaryKey { get; set; }

        [BsonElement("Utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [BsonElement("PointageLocal")]
        public int PointageLocal { get; set; }
        [BsonElement("PointageVisiteur")]
        public int PointageVisiteur { get; set; }

    }
}
