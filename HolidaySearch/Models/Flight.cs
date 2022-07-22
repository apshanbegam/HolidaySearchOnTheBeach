using System;
namespace HolidaySearch.Models
{
    public class Flight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public float price { get; set; }
        public DateOnly departure_date { get; set; }
    }
}
