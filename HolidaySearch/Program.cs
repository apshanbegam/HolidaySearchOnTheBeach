
using Search.Models;


namespace Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var holidaySearch = new HolidaySearch() { DepartingFrom = "MAN", TravelingTo = "LPA", DepartureDate = "2024-11-10", Duration = 14 };

            holidaySearch.Results();


        }
    }
}
