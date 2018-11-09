using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.Pass.Website
{
    public class Utilisateur : Entite
    {
        [BsonElement("Nom")]
        public string Nom { get; set; }
        [BsonElement("Prenom")]
        public string Prenom { get; set; }
        [BsonElement("Courriel")]
        public string Courriel { get; set; }
        [BsonElement("MotPasse")]
        public string MotPasse { get; set; }
        [BsonElement("EstAdministrateur")]
        public string EstAdministrateur { get; set; }

        [BsonElement("Solde")]
        public decimal Solde { get; set; }

        public string Affichage => Prenom + " " + Nom;

        public string Recherche => (Prenom + "|" + Nom + "|" + Courriel).ToLower();
    }


}