using Search.Models;
using FluentAssertions;
namespace Search.Tests
{
    public class HolidaySearchTests
    {
    
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_Given_Input()
        {
            var holidaySearch = new HolidaySearch() { DepartingFrom = "MAN", TravelingTo = "AGP", DepartureDate = "2023-07-01", Duration = 7 };

            Result result = new Result();
            result = holidaySearch.Results();      ;
            result.TotalPrice.Should().Be(826);
            result.Flight.Id.Should().Be(2);
            result.Flight.Airline.Should().Be("Oceanic Airlines");
            result.Flight.From.Should().Be("MAN");
            result.Flight.To.Should().Be("AGP");
            result.Flight.Price.Should().Be(245);
            result.Hotel.Id.Should().Be(9);
            result.Hotel.Name.Should().Be("Nh Malaga");
            result.Hotel.Price_per_night.Should().Be(83);

        }
    }
}


