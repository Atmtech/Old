using ATMTECH.PredictionNHL.Entites;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ATMTECH.PredictionNHL.Services
{
    public class NhlService : BaseService
    {
      
        public string ObtenirDateDebutSaison()
        {
            //return "2019-10-02";
            return "2018-10-04";
        }

        public string ObtenirDateFinSaison()
        {
            //return "2020-04-04";
            return "2019-04-04";
        }



        public NhlSchedule ObtenirCedule(string dateDepart, string dateFin)
        {
            var client = new RestClient("https://statsapi.web.nhl.com/api/v1/");
            var request = new RestRequest(string.Format("schedule?startDate={0}&endDate={1}&expand=schedule.teams", dateDepart, dateFin));
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return  new JsonDeserializer().Deserialize<NhlSchedule>(response);
            }
            return null;
        }

        public IList<DTOVisiteurLocal> ConvertirCeduleVisiteurLocal(string dateDepart, string dateFin, Utilisateur utilisateur)
        {
            NhlSchedule ceduleTotal =  ObtenirCedule(dateDepart, dateFin);

            string id =   utilisateur.Id.ToString();
            IList<Prediction> predictions = new PredictionService().ObtenirPrediction().Where(x=>x.Utilisateur.Id == utilisateur.Id).ToList();

            IList<DTOVisiteurLocal> retour = new List<DTOVisiteurLocal>();
            foreach (Date dateCedule in ceduleTotal.dates)
            {
                foreach (Game game in dateCedule.games)
                {
                  Prediction prediction = predictions.FirstOrDefault(x => x.GamePrimaryKey == game.gamePk);
                    if (prediction != null)
                    {
                        retour.Add(new DTOVisiteurLocal
                        {
                            GamePrimaryKey = game.gamePk,
                            Date = dateCedule.date,
                            NomEquipeLocal = game.teams.home.team.name,
                            NomEquipeVisiteur = game.teams.away.team.name,
                            PointageLocal = game.teams.home.score,
                            PointageVisiteur = game.teams.away.score,
                            PredictionPointageLocal = prediction­.PointageLocal,
                            PredictionPointageVisiteur = prediction.PointageVisiteur,
                            EstDejaPredit = true
                        });
                    }
                    else
                    {
                        retour.Add(new DTOVisiteurLocal
                        {
                            GamePrimaryKey = game.gamePk,
                            Date = dateCedule.date,
                            NomEquipeLocal = game.teams.home.team.name,
                            NomEquipeVisiteur = game.teams.away.team.name,
                            PointageLocal = game.teams.home.score,
                            PointageVisiteur = game.teams.away.score,
                            EstDejaPredit = false
                        });
                    }


                        
                }
            }
            return retour;
        }

        public IList<string> ObtenirDateSaison()
        {
            var dates = new List<string>();

            for (var dt = Convert.ToDateTime(ObtenirDateDebutSaison()); dt <= Convert.ToDateTime(ObtenirDateFinSaison()); dt = dt.AddDays(1))
            {
                dates.Add(dt.ToShortDateString());
            }

            return dates;
        }
    }
}
