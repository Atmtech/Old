using System.Collections.Generic;

namespace ATMTECH.Expeditn.Entities.DTO
{
    public class InboundFlightEntryList
    {
        public string originToDestination { get; set; }
        public string airlineName { get; set; }
        public string flightNo { get; set; }
        public string flightClass { get; set; }
        public string departureTime { get; set; }
        public string arrivalTime { get; set; }
        public int connections { get; set; }
        public int stops { get; set; }
        public int overnights { get; set; }
    }

    public class OutboundFlightEntryList
    {
        public string originToDestination { get; set; }
        public string airlineName { get; set; }
        public string flightNo { get; set; }
        public string flightClass { get; set; }
        public string departureTime { get; set; }
        public string arrivalTime { get; set; }
        public int connections { get; set; }
        public int stops { get; set; }
        public int overnights { get; set; }
    }

    public class Package
    {
        public string itemId { get; set; }
        public int numberOfNights { get; set; }
        public string roomType { get; set; }
        public string mealPlan { get; set; }
        public string tourOperator { get; set; }
        public string departureTime { get; set; }
        public string returnTime { get; set; }
        public double price { get; set; }
        public List<InboundFlightEntryList> inboundFlightEntryList { get; set; }
        public List<OutboundFlightEntryList> outboundFlightEntryList { get; set; }
    }

    public class HotelList
    {
        public string hotelId { get; set; }
        public string hotelName { get; set; }
        public string starRating { get; set; }
        public string userRating { get; set; }
        public string userRreviewCount { get; set; }
        public string town { get; set; }
        public List<Package> packages { get; set; }
    }

    public class SearchAndFilterParams
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public string fromDate { get; set; }
        public string duration { get; set; }
        public int numAdults { get; set; }
        public int numChildren { get; set; }
        public int numRooms { get; set; }
        public string pagingFlag { get; set; }
        public int pageIndex { get; set; }
        public string tourToDisplay { get; set; }
        public string occupancy { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public string priceRange { get; set; }
        public string country { get; set; }
    }

    public class DataExpedia
    {
        public List<HotelList> hotelList { get; set; }
        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public string sortOrder { get; set; }
        public int numberOfResults { get; set; }
        public List<object> priceGridList { get; set; }
        public SearchAndFilterParams searchAndFilterParams { get; set; }
        public string currency { get; set; }
        public string language { get; set; }
    }

    public class RootObject
    {
        public DataExpedia data { get; set; }
    }
}
