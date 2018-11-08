using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.StockGame.Entites
{
    public class LogOrdre : Entite
    {
        [BsonElement("Log")]
        public string Log { get; set; }
    }
}
