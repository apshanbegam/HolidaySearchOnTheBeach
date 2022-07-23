using System;
namespace Search.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public float Price { get; set; }
        public string Departure_Date { get; set; }
    }
}
