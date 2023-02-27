// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.Core.Services;
using AM.Core.Extensions;

Console.WriteLine("Hello, World!");


#region 30/01/2023

//les trois techniques 

// Question 7 

Plane plane = new Plane();
plane.ManufacturedDate = new DateTime(2000,1,1);
plane.Capacity= 200;
plane.MyPlaneType = PlaneType.Boing; 



// Question 8

Plane plane2 = new Plane(PlaneType.Boing, 100, new DateTime(2001, 04, 02)) ;

// Question 9

Plane plane3 = new Plane() {Capacity = 200 , PlaneId = 2 };






#endregion

#region 6/02/2023
//TP1.Q12.b
Passenger passenger = new Passenger();
Passenger traveller = new Traveller();
Passenger staff = new Staff();

//Console.WriteLine(passenger.GetPassengerType());
//Console.WriteLine(traveller.GetPassengerType());
//Console.WriteLine(staff.GetPassengerType());

// TP1.Q13.c
passenger.BirthDate = new DateTime(2020, 6, 2);
passenger.GetAge(passenger);
Console.WriteLine(passenger.Age);
int age = 0;
passenger.GetAge(new DateTime(2020, 6, 2), ref age);
Console.WriteLine(age);
#endregion

//TP2 Q13 c
IFlightService flightService = new FlightService();
IFlightService.GetScore scoreByNbrFlight = delegate (Passenger p)
{
    return p.Flights.Count();
};

IFlightService.GetScore scoreByNbrFlightTunis = delegate (Passenger p)
{
    return p.Flights
    .Where(f=>f.Destination=="Tunis"|| f.Departure=="Tunis")
    .Count();
};

flightService.GetSeniorPassenger(scoreByNbrFlight);
flightService.GetSeniorPassenger(scoreByNbrFlightTunis);


//TP2 Q14
Flight flight = new Flight();
