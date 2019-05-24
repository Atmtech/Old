using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Vachier.WebSite
{
    public class Entite
    {
        public ObjectId Id { get; set; }
    }

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

    public class Insulte : Entite
    {

        [BsonElement("DateCreation")]
        public DateTime DateCreation { get; set; }
        [BsonElement("Titre")]
        public string Titre { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Localisation")]
        public Localisation Localisation { get; set; }
        [BsonElement("NombreJaime")]
        public int NombreJaime { get; set; }

        public string AffichagePaysRegionVille => Localisation.Pays + ", " + Localisation.Region + " " + Localisation.Ville;

        public string PourGoogle => Localisation.Pays + "+" + Localisation.Region + "+" + Localisation.Ville;
    }

    public class LocalisationTopGroupe
    {
        public string Localisation { get; set; }
        public int Compte { get; set; }
    }

}