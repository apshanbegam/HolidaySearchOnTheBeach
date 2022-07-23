
using Search.Models;


namespace Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var holidaySearch = new HolidaySearch() { DepartingFrom = "MAN", TravelingTo = "AGP", DepartureDate = "2023-07-01", Duration = 7 };
          
            holidaySearch.Results();


        }
    }
}
