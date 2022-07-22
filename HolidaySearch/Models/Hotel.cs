using System;
namespace HolidaySearch.Models
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateOnly arrival_date { get; set; }
        public float price_per_night { get; set; }
        public List<string> local_airports { get; set; }
        public int nights { get; set; }
    }
}

