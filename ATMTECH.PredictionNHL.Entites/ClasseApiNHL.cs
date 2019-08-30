using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMTECH.PredictionNHL.Entites
{
    public class Status
    {
        public string abstractGameState { get; set; }
        public string codedGameState { get; set; }
        public string detailedState { get; set; }
        public string statusCode { get; set; }
        public bool startTimeTBD { get; set; }
    }

    public class LeagueRecord
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ot { get; set; }
        public string type { get; set; }
    }

    public class TimeZone
    {
        public string id { get; set; }
        public int offset { get; set; }
        public string tz { get; set; }
    }

    public class Venue
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public string city { get; set; }
        public TimeZone timeZone { get; set; }
    }

    public class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public string link { get; set; }
        public string abbreviation { get; set; }
    }

    public class Conference
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Franchise
    {
        public int franchiseId { get; set; }
        public string teamName { get; set; }
        public string link { get; set; }
    }

    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public Venue venue { get; set; }
        public string abbreviation { get; set; }
        public string teamName { get; set; }
        public string locationName { get; set; }
        public string firstYearOfPlay { get; set; }
        public Division division { get; set; }
        public Conference conference { get; set; }
        public Franchise franchise { get; set; }
        public string shortName { get; set; }
        public string officialSiteUrl { get; set; }
        public int franchiseId { get; set; }
        public bool active { get; set; }
    }

    public class Away
    {
        public LeagueRecord leagueRecord { get; set; }
        public int score { get; set; }
        public Team team { get; set; }
    }

    public class LeagueRecord2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ot { get; set; }
        public string type { get; set; }
    }

    public class TimeZone2
    {
        public string id { get; set; }
        public int offset { get; set; }
        public string tz { get; set; }
    }

    public class Venue2
    {
        public string name { get; set; }
        public string link { get; set; }
        public string city { get; set; }
        public TimeZone2 timeZone { get; set; }
        public int? id { get; set; }
    }

    public class Division2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public string link { get; set; }
        public string abbreviation { get; set; }
    }

    public class Conference2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Franchise2
    {
        public int franchiseId { get; set; }
        public string teamName { get; set; }
        public string link { get; set; }
    }

    public class Team2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public Venue2 venue { get; set; }
        public string abbreviation { get; set; }
        public string teamName { get; set; }
        public string locationName { get; set; }
        public string firstYearOfPlay { get; set; }
        public Division2 division { get; set; }
        public Conference2 conference { get; set; }
        public Franchise2 franchise { get; set; }
        public string shortName { get; set; }
        public string officialSiteUrl { get; set; }
        public int franchiseId { get; set; }
        public bool active { get; set; }
    }

    public class Home
    {
        public LeagueRecord2 leagueRecord { get; set; }
        public int score { get; set; }
        public Team2 team { get; set; }
    }

    public class Teams
    {
        public Away away { get; set; }
        public Home home { get; set; }
    }

    public class Venue3
    {
        public string name { get; set; }
        public string link { get; set; }
        public int? id { get; set; }
    }

    public class Content
    {
        public string link { get; set; }
    }

    public class Game
    {
        public int gamePk { get; set; }
        public string link { get; set; }
        public string gameType { get; set; }
        public string season { get; set; }
        public DateTime gameDate { get; set; }
        public Status status { get; set; }
        public Teams teams { get; set; }
        public Venue3 venue { get; set; }
        public Content content { get; set; }
    }

    public class Date
    {
        public string date { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalMatches { get; set; }
        public List<Game> games { get; set; }
        public List<object> events { get; set; }
        public List<object> matches { get; set; }
    }

    public class NhlSchedule
    {
        public string copyright { get; set; }
        public int totalItems { get; set; }
        public int totalEvents { get; set; }
        public int totalGames { get; set; }
        public int totalMatches { get; set; }
        public int wait { get; set; }
        public List<Date> dates { get; set; }
    }
}