using Search.SearchModels;

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

            var holidaySearch = new HolidaySearch(departingFrom: "MAN",
                                                  travelingTo: "AGP",
                                                  departureDate: "2023/07/01",
                                                  duration: 7
                                                  );
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
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_LGW_PMI()
        {
            var holidaySearch = new HolidaySearch(departingFrom: "LGW",
                                                  travelingTo: "PMI",
                                                  departureDate: "2023-06-15",
                                                  duration: 10);

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
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_MAN_LPA()
        {
            var holidaySearch = new HolidaySearch(departingFrom: "MAN",
                                                  travelingTo: "LPA",
                                                  departureDate: "2022-11-10",
                                                  duration: 14);

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

        [Test]
        public void HandlingEmptyLists()
        {
            var holidaySearch = new HolidaySearch(departingFrom: "MAN",
                                                  travelingTo: "LGW",
                                                  departureDate: "2024-11-10",
                                                  duration: 14);
            Exception ex = Assert.Throws<Exception>(() => holidaySearch.Results());
            Assert.That(ex.Message, Is.EqualTo("Flight or Hotel is not present for given input"));


        }

        [Test]
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_Any_London_Airports()
        {
            var holidaySearch = new HolidaySearch(departingFrom: "Any London Airport",
                                                  travelingTo: "PMI",
                                                  departureDate: "2023/06/15",
                                                  duration: 10);

            holidaySearch.Results().First().TotalPrice.Should().Be(675);
            holidaySearch.Results().First().Flight.Id.Should().Be(6);
            holidaySearch.Results().First().Hotel.Id.Should().Be(5);


        }

        [Test]
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_Any_Airports()
        {
            var holidaySearch = new HolidaySearch(departingFrom: "Any Airport",
                                                  travelingTo: "LPA",
                                                  departureDate: "2022/11/10",
                                                  duration: 14);

            holidaySearch.Results().First().TotalPrice.Should().Be(1175);
            holidaySearch.Results().First().Flight.Id.Should().Be(7);
            holidaySearch.Results().First().Hotel.Id.Should().Be(6);


        }

        [Test]
        public void Get_Correct_Results_Of_Flight_And_Hotel_For_Empty_Departing_From()
        {
            var holidaySearch = new HolidaySearch(departingFrom: "",
                                                  travelingTo: "LPA",
                                                  departureDate: "2022/11/10",
                                                  duration: 14);

            holidaySearch.Results().First().TotalPrice.Should().Be(1175);
            holidaySearch.Results().First().Flight.Id.Should().Be(7);
            holidaySearch.Results().First().Hotel.Id.Should().Be(6);


        }

    }

}
