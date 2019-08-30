using ATMTECH.PredictionNHL.Entites;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATMTECH.PredictionNHL.Web
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://statsapi.web.nhl.com/api/v1/");
            var request = new RestRequest("schedule?startDate=2018-11-02&endDate=2018-11-02&expand=schedule.teams");
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Two ways to get the result:
                string rawResponse = response.Content;
                NhlSchedule nHLSchedule = new JsonDeserializer().Deserialize<NhlSchedule>(response);

                foreach (Date dateCedule in nHLSchedule.dates)
                {
                    Response.Write("<H1>" + dateCedule.date + "</H1>");
                    foreach (Game game in dateCedule.games)
                    {
                        //Response.Write(game.teams.home.team.name);
                        string horaire = string.Format("{0} vs {1} ({2}-{3})", game.teams.away.team.name, game.teams.home.team.name, game.teams.away.score, game.teams.home.score);
                        Response.Write(horaire + "<br>");
                    }
                }
                //(new System.Collections.Generic.Mscorlib_CollectionDebugView<ATMTECH.PredictionNHL.Web.Date>(nHLSchedule.dates).Items[0]).games
            }

            //      NHLSchedule modeleExpedia = new JavaScriptSerializer().Deserialize<NHLSchedule>(html);
        }

    }
}