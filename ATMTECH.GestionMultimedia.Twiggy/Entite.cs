using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.GestionMultimedia.Twiggy
{
    public class Entite
    {
        public ObjectId Id { get; set; }
    }

    public class Multimedia : Entite
    {
        [BsonElement("DateCreation")]
        public DateTime DateCreation { get; set; }

        [BsonElement("NoGroupe")]
        public string NoGroupe { get; set; }
        [BsonElement("Style")]
        public string Style { get; set; }
        [BsonElement("Etudiants")]
        public string Etudiants { get; set; }
        [BsonElement("UrlMedia")]
        public string UrlMedia { get; set; }

    }

}