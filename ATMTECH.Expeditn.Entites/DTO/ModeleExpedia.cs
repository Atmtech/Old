using System;
using System.Collections.Generic;

namespace ATMTECH.Expeditn.Entites.DTO
{

    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class PricesPerPassenger
    {
        public string type { get; set; }
        public object age { get; set; }
        public int price { get; set; }
    }

    public class Price
    {
        public Currency currency { get; set; }
        public int basePrice { get; set; }
        public int pricePerPassenger { get; set; }
        public int? highestPricePerPassenger { get; set; }
        public int taxesAndFees { get; set; }
        public object changeType { get; set; }
        public List<PricesPerPassenger> pricesPerPassengers { get; set; }
        public int totalPrice { get; set; }
        public int numberOfAdults { get; set; }
        public int numberOfChildren { get; set; }
        public int numberOfInfant { get; set; }
    }

    public class Airline
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class FareCategory
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Airport
    {
        public string code { get; set; }
        public string city { get; set; }
    }

    public class Departure
    {
        public Airport airport { get; set; }
        public DateTime localTime { get; set; }
    }

    public class Airport2
    {
        public string code { get; set; }
        public string city { get; set; }
    }

    public class Arrival
    {
        public Airport2 airport { get; set; }
        public DateTime localTime { get; set; }
    }

    public class FlightSegment
    {
        public string code { get; set; }
        public Airline airline { get; set; }
        public FareCategory fareCategory { get; set; }
        public Departure departure { get; set; }
        public Arrival arrival { get; set; }
        public bool overnight { get; set; }
        public int durationInMilliseconds { get; set; }
    }

    public class DepartureFlight
    {
        public List<FlightSegment> flightSegments { get; set; }
        public int numStops { get; set; }
        public bool nonStop { get; set; }
        public bool redeye { get; set; }
    }

    public class Airline2
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class FareCategory2
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Airport3
    {
        public string code { get; set; }
        public string city { get; set; }
    }

    public class Departure2
    {
        public Airport3 airport { get; set; }
        public DateTime localTime { get; set; }
    }

    public class Airport4
    {
        public string code { get; set; }
        public string city { get; set; }
    }

    public class Arrival2
    {
        public Airport4 airport { get; set; }
        public DateTime localTime { get; set; }
    }

    public class FlightSegment2
    {
        public string code { get; set; }
        public Airline2 airline { get; set; }
        public FareCategory2 fareCategory { get; set; }
        public Departure2 departure { get; set; }
        public Arrival2 arrival { get; set; }
        public bool overnight { get; set; }
        public int durationInMilliseconds { get; set; }
    }

    public class ReturnFlight
    {
        public List<FlightSegment2> flightSegments { get; set; }
        public int numStops { get; set; }
        public bool nonStop { get; set; }
        public bool redeye { get; set; }
    }

    public class Trip
    {
        public DepartureFlight departureFlight { get; set; }
        public ReturnFlight returnFlight { get; set; }
        public object naturalKey { get; set; }
    }

    public class Rating
    {
        public string type { get; set; }
        public double value { get; set; }
    }

    public class Room
    {
        public string type { get; set; }
    }

    public class Occupancy
    {
        public string code { get; set; }
        public string description { get; set; }
    }

    public class MealPlan
    {
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ReviewSummary
    {
        public int total { get; set; }
        public string hotelId { get; set; }
        public double averageOverallRating { get; set; }
        public double recommendedPercent { get; set; }
        public double roomCleanliness { get; set; }
        public double serviceAndStaff { get; set; }
        public double roomComfort { get; set; }
        public double hotelCondition { get; set; }
    }

    public class Hotel
    {
        public string expediaId { get; set; }
        public string supplierId { get; set; }
        public string primaryPhoto { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string checkIn { get; set; }
        public string checkOut { get; set; }
        public List<Rating> rating { get; set; }
        public List<Room> rooms { get; set; }
        public Occupancy occupancy { get; set; }
        public object amenities { get; set; }
        public MealPlan mealPlan { get; set; }
        public ReviewSummary reviewSummary { get; set; }
        public object hotelCode { get; set; }
        public object latitude { get; set; }
        public object longitude { get; set; }
        public string link { get; set; }
        public object hotelAttributes { get; set; }
        public int roomCount { get; set; }
    }

    public class TourOperator
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Extra
    {
        public string code { get; set; }
        public string name { get; set; }
        public object description { get; set; }
    }

    public class Offer
    {
        public string id { get; set; }
        public object technologyProvider { get; set; }
        public Price price { get; set; }
        public Trip trip { get; set; }
        public Hotel hotel { get; set; }
        public TourOperator tourOperator { get; set; }
        public List<Extra> extras { get; set; }
        public string availabilityStatus { get; set; }
        public object earnedPoints { get; set; }
        public object address { get; set; }
        public bool available { get; set; }
    }

    public class ModeleExpedia
    {
        public List<Offer> offers { get; set; }
    }
}
