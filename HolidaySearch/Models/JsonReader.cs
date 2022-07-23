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
            
            using (var streamReader = new StreamReader(@"FlightData.json"))
            {
                string json = streamReader.ReadToEnd();
                Flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            }
            return Flights;
        }

        
        public List<Hotel> LoadHotelJson()
        {
            using (var streamReader = new StreamReader(@"HotelData.json"))
            {
                string json = streamReader.ReadToEnd();
                Hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            return Hotels;
        }

      
    }
}

