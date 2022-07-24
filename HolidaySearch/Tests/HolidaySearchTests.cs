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

            holidaySearch.Results().First();
            holidaySearch.Results().First().TotalPrice.Should().Be(826);
            holidaySearch.Results().First().Flight.Id.Should().Be(2);
            holidaySearch.Results().First().Flight.Airline.Should().Be("Oceanic Airlines");
            holidaySearch.Results().First().Flight.From.Should().Be("MAN");
            holidaySearch.Results().First().Flight.To.Should().Be("AGP");
            holidaySearch.Results().First().Flight.Price.Should().Be(245);
            holidaySearch.Results().First().Hotel.Id.Should().Be(9);
            holidaySearch.Results().First().Hotel.Name.Should().Be("Nh Malaga");
            holidaySearch.Results().First().Hotel.Price_per_night.Should().Be(83);

        }


        [Test]
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_Given_All_London_Airport()
        {
            var holidaySearch = new HolidaySearch() { DepartingFrom = "LGW", TravelingTo = "PMI", DepartureDate = "2023-06-15", Duration = 10};

            holidaySearch.Results().First();
            holidaySearch.Results().First().TotalPrice.Should().Be(675);
            holidaySearch.Results().First().Flight.Id.Should().Be(6);
            holidaySearch.Results().First().Flight.Airline.Should().Be("Fresh Airways");
            holidaySearch.Results().First().Flight.From.Should().Be("LGW");
            holidaySearch.Results().First().Flight.To.Should().Be("PMI");
            holidaySearch.Results().First().Flight.Price.Should().Be(75);
            holidaySearch.Results().First().Hotel.Id.Should().Be(5);
            holidaySearch.Results().First().Hotel.Name.Should().Be("Sol Katmandu Park & Resort");
            holidaySearch.Results().First().Hotel.Price_per_night.Should().Be(60);

        }

        [Test]
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_Given_All_Departing_Airport()
        {
            var holidaySearch = new HolidaySearch() { DepartingFrom = "MAN", TravelingTo = "LPA", DepartureDate = "2022-11-10", Duration = 14 };

            holidaySearch.Results().First();
            holidaySearch.Results().First().TotalPrice.Should().Be(1175);
            holidaySearch.Results().First().Flight.Id.Should().Be(7);
            holidaySearch.Results().First().Flight.Airline.Should().Be("Trans American Airlines");
            holidaySearch.Results().First().Flight.From.Should().Be("MAN");
            holidaySearch.Results().First().Flight.To.Should().Be("LPA");
            holidaySearch.Results().First().Flight.Price.Should().Be(125);
            holidaySearch.Results().First().Hotel.Id.Should().Be(6);
            holidaySearch.Results().First().Hotel.Name.Should().Be("Club Maspalomas Suites and Spa");
            holidaySearch.Results().First().Hotel.Price_per_night.Should().Be(75);

        }
    }
}


