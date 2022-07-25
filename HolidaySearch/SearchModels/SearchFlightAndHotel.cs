using System;
using Search.Models;

namespace Search.SearchModels
{
    public class SearchFlightAndHotel
    {

        JsonReader jsonReader = new JsonReader();

        public List<Flight> FlightsList(string DepartingFrom, string TravelingTo, string DepartureDate)
        {
            var Flights = jsonReader.LoadFlightJson();
            List<Flight> Result;

            if (DepartingFrom.Contains("London"))
            {
                var londonAirports = ListOfLondonAirports();
                Result = (from flight in Flights
                          where londonAirports.Contains(flight.From)
                          where flight.To == TravelingTo
                          where flight.Departure_Date == DateTime.Parse(DepartureDate)
                          select flight).ToList();
            }
            else if (DepartingFrom == "Any Airport" || DepartingFrom == "" || DepartingFrom == null)
            {
                Result = (from flight in Flights
                          where flight.To == TravelingTo
                          where flight.Departure_Date == DateTime.Parse(DepartureDate)
                          select flight).ToList();

            }
            else
            {
                Result = (from flight in Flights
                          where flight.From == DepartingFrom
                          where flight.To == TravelingTo
                          where flight.Departure_Date == DateTime.Parse(DepartureDate)
                          select flight).ToList();
            }

            var sortedByFlightPrice = (from result in Result
                                       orderby result.Price ascending
                                       select result).ToList();
            return sortedByFlightPrice;
        }

        public List<Hotel> HotelsList(string DepartureDate, string TravelingTo, int Duration)
        {
            var Hotels = jsonReader.LoadHotelJson();
            var Result = from hotel in Hotels
                         where hotel.Arrival_date == DateTime.Parse(DepartureDate)
                         where hotel.Local_airports.Contains(TravelingTo)
                         where hotel.Nights == Duration
                         select hotel;

            var sortedByHotelPrice = from result in Result
                                     orderby result.Price_per_night ascending
                                     select result;

            return sortedByHotelPrice.ToList();
        }

        private List<string> ListOfLondonAirports()
        {
            var LondonAirports = new List<string> { "LGW", "LTN" };
            return LondonAirports;
        }
    }
}

