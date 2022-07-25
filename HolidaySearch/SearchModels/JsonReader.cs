using Newtonsoft.Json;
using Search.Models;

namespace Search.SearchModels
{
    public class JsonReader
    {
        public List<Flight> LoadFlightJson()
        {
            var Flights = new List<Flight>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"../../../Data/FlightData.json");

            using (var streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                Flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            }
            return Flights;
        }


        public List<Hotel> LoadHotelJson()
        {
            var Hotels = new List<Hotel>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"../../../Data/HotelData.json");
            using (var streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                Hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            return Hotels;
        }


    }
}

