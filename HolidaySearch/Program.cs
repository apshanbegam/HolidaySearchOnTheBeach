
using Search.Models;


namespace Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var holidaySearch = new HolidaySearch() { DepartingFrom = "MAN", TravelingTo = "LGW", DepartureDate = "2022-11-10", Duration = 14 };

            holidaySearch.Results();


        }
    }
}
