using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Expeditn.Entites
{
    public class Expedition : Entite
    {
        [BsonElement("Titre")]
        public string Titre { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Debut")]
        public DateTime Debut { get; set; }
        [BsonElement("Image")]
        public string Image { get; set; }
        [BsonElement("Fin")]
        public DateTime Fin { get; set; }
        [BsonElement("ListeUtilisateur")]
        public IList<Utilisateur> ListeUtilisateur { get; set; }
        [BsonElement("ListeActivite")]
        public IList<Activite> ListeActivite { get; set; }
        [BsonElement("ListeDepense")]
        public IList<Depense> ListeDepense { get; set; }
        [BsonElement("Administrateur")]
        public Utilisateur Administrateur { get; set; }


    }


}