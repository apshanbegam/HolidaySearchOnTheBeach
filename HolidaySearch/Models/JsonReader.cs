using System;
using System.IO;
using Newtonsoft.Json;
using System.Globalization;

namespace Search.Models
{
    public class JsonReader
    {
        List<Flight> Flights;
        List<Hotel> Hotels;

        public List<Flight> LoadFlightJson()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"Data/FlightData.json");
           
            using (var streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                Flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            }
            return Flights;
        }

        
        public List<Hotel> LoadHotelJson()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $@"Data/HotelData.json");
            using (var streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                Hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            return Hotels;
        }

      
    }
}

