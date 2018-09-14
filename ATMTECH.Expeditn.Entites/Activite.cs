using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
    public class Activite : Entite
    {
        [BsonElement("Nom")]
        public string Nom { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("TypeActivite")]
        public string TypeActivite { get; set; }
        [BsonElement("Date")]
        public DateTime Date { get; set; }
        [BsonElement("ListeUtilisateur")]
        public IList<Utilisateur> ListeUtilisateur { get; set; }
    }


}