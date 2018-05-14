using System;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATMTECH.AirTerreMer.WebSite
{
    public class Entite
    {
        public ObjectId Id { get; set; }
    }

    public class Reservation : Entite
    {
        [BsonElement("DateCreation")]
        public DateTime DateCreation { get; set; }

        [BsonElement("DateReservation")]
        public DateTime DateReservation { get; set; }
        
        [BsonElement("Nom")]
        public string Nom { get; set; }
        [BsonElement("Prenom")]
        public string Prenom { get; set; }
        [BsonElement("Courriel")]
        public string Courriel { get; set; }

        [BsonElement("PreferenceCulinaire1")]
        public string PreferenceCulinaire1 { get; set; }

        [BsonElement("PreferenceCulinaire2")]
        public string PreferenceCulinaire2 { get; set; }

        [BsonElement("PreferenceCulinaire3")]
        public string PreferenceCulinaire3 { get; set; }


        [BsonElement("PreferenceCulinaire4")]
        public string PreferenceCulinaire4 { get; set; }

        [BsonElement("PreferenceCulinaire5")]
        public string PreferenceCulinaire5{ get; set; }

        [BsonElement("PreferenceCulinaire6")]
        public string PreferenceCulinaire6 { get; set; }


        [BsonElement("BudgetEpicerieMaximal")]
        public string BudgetEpicerieMaximal { get; set; }

        [BsonElement("NombreConvive")]
        public string NombreConvive { get; set; }

        [BsonElement("Telephone")]
        public string Telephone { get; set; }

        [BsonElement("AllergieIntolerance")]
        public string AllergieIntolerance { get; set; }
        [BsonElement("InformationSupplementaire")]
        public string InformationSupplementaire { get; set; }

        [BsonElement("Localisation")]
        public Localisation Localisation { get; set; }
        [BsonElement("NomMenu")]
        public string NomMenu { get; set; }

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

    public class DateReservation
    {
        public DateTime Date { get; set; }

        public string Affichage
        {
            get
            {
                if (Date.Year.ToString() == "9999")
                    return "";
                CultureInfo ci = CultureInfo.CreateSpecificCulture("fr-FR");
                return char.ToUpper( Date.ToString("dddd ", ci)[0])+ Date.ToString("dddd ", ci).Substring(1) + Date.ToString("d ", ci) + " " +  Date.ToString("Y", ci); ; ;
            }
        }
    }

}