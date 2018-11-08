using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.StockGame.Entites
{
    public class Titre : Entite
    {
        [BsonElement("Utilisateur")]
        public Utilisateur Utilisateur { get; set; }

        [BsonElement("Bourse")]
        public string Bourse { get; set; }


        [BsonElement("Code")]
        public string Code { get; set; }

        [BsonElement("DateDerniereTransaction")]
        public string DateDerniereTransaction { get; set; }


        [BsonElement("Nom")]
        public string Nom { get; set; }
        [BsonElement("DateAchat")]
        public DateTime DateAchat { get; set; }
        [BsonElement("ValeurAchat")]
        public decimal ValeurAchat { get; set; }
        [BsonElement("ValeurVendu")]
        public decimal ValeurVendu { get; set; }
        [BsonElement("ValeurActuelle")]
        public decimal ValeurActuelle { get; set; }
        [BsonElement("Nombre")]
        public int Nombre { get; set; }
        [BsonElement("CommissionVendu")]
        public decimal CommissionVendu { get; set; }

        [BsonElement("CommissionAchat")]
        public decimal CommissionAchat { get; set; }


        [BsonElement("PourcentageVariationEntreFermetureEtActuel")]
        public decimal PourcentageVariationEntreFermetureEtActuel { get; set; }

        [BsonElement("ValeurOuverture")]
        public decimal ValeurOuverture { get; set; }

        [BsonElement("ValeurOrdrePourVendre")]
        public decimal ValeurOrdrePourVendre { get; set; }

        [BsonElement("Logo")]
        public string Logo { get; set; }



        public decimal ValeurActuelleTotale => ValeurActuelle * Nombre;
        public decimal ValeurAchatTotale => ValeurAchat * Nombre;


        public decimal PourcentageVariationActuelle
        {
            get { return ValeurActuelle != 0 ? Math.Round((1 - ValeurAchat / ValeurActuelle) * 100, 2) : 0; }
        }

        public decimal Profit => ValeurActuelleTotale - ValeurAchatTotale - CommissionAchat;


    }
}
