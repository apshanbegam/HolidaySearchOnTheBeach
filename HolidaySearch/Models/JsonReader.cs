using System;
using Newtonsoft.Json;

namespace HolidaySearch.Models
{
    public class JsonReader
    {
        public void LoadFlightJson()
        {
            using (StreamReader r = new StreamReader(@"Data\FlightData.json"))
            {
                string json = r.ReadToEnd();
                List<Flight> Flights = JsonConvert.DeserializeObject<List<Flight>>(json);
            }
        }

        
        public void LoadHotelJson()
        {
            using (StreamReader r = new StreamReader(@"Data\HotelData.json"))
            {
                string json = r.ReadToEnd();
                List<Hotel> Hotels = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
        }

      
    }
}

