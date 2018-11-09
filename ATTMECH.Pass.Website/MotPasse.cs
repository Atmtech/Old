using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Pass.Website
{
    public class MotPasse : Entite
    {
        [BsonElement("Courriel")]
        public string Courriel { get; set; }

        [BsonElement("MotDePasse")]
        public string MotDePasse { get; set; }

        [BsonElement("Emplacement")]
        public string Emplacement { get; set; }

        [BsonElement("Utilisateur")]
        public Utilisateur Utilisateur { get; set; }

    }
}