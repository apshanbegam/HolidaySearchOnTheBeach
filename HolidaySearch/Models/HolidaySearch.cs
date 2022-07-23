using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace Search.Models
{
    public class HolidaySearch
    {
        
        [Key]
        public string DepartingFrom { get;  set; }
        public string TravelingTo { get; set; }
        public string DepartureDate { get; set; }
        public int Duration { get; set; }

        List<Flight> Flights;
        List<Hotel> Hotels;
        Result result = new Result();

        JsonReader jsonReader = new JsonReader();
        
        public void loadData()
        {
            Flights = jsonReader.LoadFlightJson();
            Hotels = jsonReader.LoadHotelJson();
            
        }

        public Result Results()
        {
            loadData();
            var Result1 = from flight in Flights
                               where flight.From == DepartingFrom
                               where flight.To == TravelingTo
                               where flight.Departure_Date == DepartureDate
                               select flight;

            var sortedByFlightPrice = from result in Result1
                                           orderby result.Price ascending
                                           select result;
            var FlightResults = sortedByFlightPrice.ToList();

            var Result2 = from hotel in Hotels
                                where hotel.Arrival_date == DepartureDate
                                where hotel.Local_airports.Contains(TravelingTo)
                                where hotel.Nights == Duration
                                select hotel;
           
            var sortedByHotelPrice = from result in Result2
                                     orderby result.Price_per_night ascending
                                     select result;

            var HotelResults = sortedByHotelPrice.ToList();

            
            result.TotalPrice = FlightResults.First().Price + HotelResults[0].Price_per_night * Duration;
            result.Flight = FlightResults.First();
            result.Hotel = HotelResults.First();
            Console.WriteLine(result.TotalPrice);

            return result;
        }


    }
}

