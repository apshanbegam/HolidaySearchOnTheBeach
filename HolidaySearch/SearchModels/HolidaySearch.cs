using Search.Models;

namespace Search.SearchModels
{
    public class HolidaySearch
    {

        private string DepartingFrom { get; set; }
        private string TravelingTo { get; set; }
        private string DepartureDate { get; set; }
        private int Duration { get; set; }

        public HolidaySearch(string departingFrom, string travelingTo, string departureDate, int duration)
        {
            DepartingFrom = departingFrom;
            TravelingTo = travelingTo;
            DepartureDate = departureDate;
            Duration = duration;
        }


        public List<Result> Results()
        {
            SearchFlightAndHotel fh = new SearchFlightAndHotel();
            var ResultList = new List<Result>();
            try

            {
                var FlightResults = fh.FlightsList(DepartingFrom, TravelingTo, DepartureDate);
                var HotelResults = fh.HotelsList(DepartureDate, TravelingTo, Duration);

                if (FlightResults != null && HotelResults != null && FlightResults.Count > 0 && HotelResults.Count > 0)
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
                        }
                    }

                }
                else
                {
                    throw new Exception("Flight or Hotel is not present for given input");
                }

            }
            catch (Exception e)
            {
                //Handling Error
                throw;
            }

            return ResultList;

        }

    }
}

