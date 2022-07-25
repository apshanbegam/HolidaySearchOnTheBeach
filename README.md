# HolidaySearchOnTheBeach

This repository contains a C# application that allows to 
read data of Hotels and Flights from a Json file (FlightData.json , HotelData.json) and 
create a small library of code that provides a  holiday search feature based on Inputs.


# Instructions
Prerequisite: The machine running the application should have .NET 6.0 (or above) installed.

To run the application:

clone the repository to your computer

[HolidaySearchOnTheBeach](https://github.com/apshanbegam/HolidaySearchOnTheBeach.git)

then navigate to the HolidaySearch folder (with cd command or otherwise)
then run the command. 

```bash
dotnet run
```

To Run Unit Tests

In terminal and inside the root folder of the project HolidaySearcher:
Run the command. 

```bash
dotnet test
```

Sample Input:

var holidaySearch = new HolidaySearch({
      DepartingFrom: 'MAN',
      TravelingTo: 'AGP',
      DepartureDate: '2023/07/01'
      Duration: 7
      });
      
      
Expected result:

 * Flight 2 and Hotel 9

