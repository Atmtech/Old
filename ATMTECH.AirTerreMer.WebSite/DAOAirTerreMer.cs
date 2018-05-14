using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ATMTECH.AirTerreMer.WebSite
{
    public class DAOAirTerreMer : BaseDAO
    {

        public IList<Reservation> ObtenirReservation()
        {
            IMongoCollection<Reservation> mongoCollection = Database.GetCollection<Reservation>("Reservation");
            return mongoCollection.AsQueryable().ToList();
        }

        public void AjouterMenu(string id, string nomMenu)
        {
            IMongoCollection<Reservation> mongoCollection = Database.GetCollection<Reservation>("Reservation");
        //    Task<Reservation> singleAsync = mongoCollection.Find(x => x.Id == ObjectId.Parse(id)).SingleAsync();
            var updoneresult = mongoCollection.UpdateOneAsync(
                Builders<Reservation>.Filter.Eq("_id", ObjectId.Parse(id)),
                Builders<Reservation>.Update.Set("NomMenu", nomMenu));
        }

        public IList<string> ObtenirListeBudget()
        {
            IList<string> retour = new List<string>();
            retour.Add("");
            retour.Add("100$ et moins");
            retour.Add("100$ et 150$");
            retour.Add("150$ et 200$");
            retour.Add("200$ et 250$");
            retour.Add("250$ et 300$");
            retour.Add("300$ et 400$");
            retour.Add("500$ et +");
            return retour;
        }

        public IList<string> ObtenirListeConvive()
        {
            IList<string> retour = new List<string>();
            retour.Add("");
            retour.Add("1");
            retour.Add("2");
            retour.Add("3");
            retour.Add("4");
            retour.Add("5");
            retour.Add("6");
            retour.Add("7");
            retour.Add("8");
            retour.Add("9");
            retour.Add("10");
            return retour;
        }

        public IList<string> ObtenirListePreferenceCulinaire()
        {
            IList<string> retour = new List<string>();
            retour.Add("Agneau");
            retour.Add("Porc");
            retour.Add("Poisson");
            retour.Add("Volaille");
            retour.Add("Boeuf");
            retour.Add("Crustacé");
            retour.Add("Mollusque");
            retour.Add("Pâtes");
            retour.Add("Végétarien");
            retour.Add("Barbecue");
            retour.Add("Italien");
            retour.Add("Gibier");
            retour.Add("Terroir du Québec");
            retour.Add("Sushi");
            retour.Add("Soupe");
            retour.Add("Soir de match");
            retour.Add("La route des épices");
            retour.Add("Piquant provenant du piment");
            retour.Add("Herbes fraiches");
            retour.Add("Tartares");
            retour.Add("Céviches");
            retour.Add("Fruits");
            retour.Add("Fumoir");
            retour.Add("Friture");
            retour.Add("Cuisine du monde - Asie");
            retour.Add("Cuisine du monde - Afrique");
            retour.Add("Cuisine du monde - Europe");
            retour.Add("Cuisine du monde - Amérique du sud");
            retour.Add("Cuisine du monde - Amérique centrale");
            retour.Add("Cuisine du monde - Amérique du Nord");
            retour.Add("Nous ne mangeons pas de tout");
            retour.Add("Exploration");
            retour.Add("Bière");
            retour.Add("Spiritueux");
            retour.Add("Vin");
            retour.Add("Cidre");
            retour.Add("Fast-food");

            retour = retour.OrderBy(x => x).ToList();
            retour.Insert(0, "");
            return retour;
        }

        public IList<DateReservation> ObtenirListeDateReservation()
        {
            IList<DateReservation> retour = new List<DateReservation>();

            for (int mois = 1; mois < 13; mois++)
            {
                for (DateTime date = new DateTime(DateTime.Now.Year, mois, 1); date.Month == mois; date = date.AddDays(1))
                {
                    if (date > DateTime.Now)
                        if (date.DayOfWeek == DayOfWeek.Monday || date.DayOfWeek == DayOfWeek.Sunday)
                            retour.Add(new DateReservation { Date = date });
                }
            }
            retour.Insert(0, new DateReservation {Date =  Convert.ToDateTime("9999-12-31")});
            return retour;
        }

        public void AjouterReservation(Reservation reservation)
        {
            IMongoCollection<Reservation> mongoCollection = Database.GetCollection<Reservation>("Reservation");

            string ip = HttpContext.Current.Request.UserHostName;
            Localisation localisation = new Localisation();
            if (ip != "127.0.0.1" && ip != "::1")
            {
                localisation = new DAOLogger().ObtenirInformationLocalisation(ip);
            }

            reservation.DateCreation = DateTime.Now;
            reservation.Localisation = localisation;
            mongoCollection.InsertOneAsync(reservation);
        }
    }
}
