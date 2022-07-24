using System.ComponentModel.DataAnnotations;
namespace Search.Models
{
    public class HolidaySearch 
    {
        [Key]
        public string DepartingFrom { get; set; }
        public string TravelingTo { get; set; }
        public string DepartureDate { get; set; }
        public int Duration { get; set; }

        List<Flight> Flights;
        List<Hotel> Hotels;
        
        List<Result> ResultList = new List<Result>();

        JsonReader jsonReader = new JsonReader();

        public HolidaySearch()
        {
            Flights = jsonReader.LoadFlightJson();
            Hotels = jsonReader.LoadHotelJson();
        }

        public List<Result> Results()
        {
            try
            {
                var FlightResults = FlightsList();
                var HotelResults = HotelsList();
                if (FlightResults!= null && HotelResults != null && FlightResults.Count > 0 && HotelResults.Count > 0)
                {
                    foreach (var f in FlightResults)
                    {
                        foreach (var h in HotelResults)
                        {
                            Result r = new Result();
                            r.TotalPrice = f.Price + (h.Price_per_night * Duration);
                            r.Flight = f;
                            r.Hotel = h;
                            ResultList.Add(r);
                            Console.WriteLine(r.TotalPrice);
                        }
                    }
                    
                }
                else
                {
                    throw new Exception("Flight or Hotel is not present for given input");
                }

            }
            catch(Exception e)
            {
                //Handling Error
                throw;
            }


            return ResultList;

        }

        public List<Flight> FlightsList()
        {
            var Result1 = from flight in Flights
                          where flight.From == DepartingFrom
                          where flight.To == TravelingTo
                          where flight.Departure_Date == DepartureDate
                          select flight;

            var sortedByFlightPrice = from result in Result1
                                      orderby result.Price ascending
                                      select result;
            return sortedByFlightPrice.ToList();
        }

        public List<Hotel> HotelsList()
        {
            var Result2 = from hotel in Hotels
                          where hotel.Arrival_date == DepartureDate
                          where hotel.Local_airports.Contains(TravelingTo)
                          where hotel.Nights == Duration
                          select hotel;

            var sortedByHotelPrice = from result in Result2
                                     orderby result.Price_per_night ascending
                                     select result;

            return sortedByHotelPrice.ToList();
        }


    }
}

