// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.ApplicationCore.Services;

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
//TP1.Question12.b
Passenger passenger = new Passenger();
Passenger traveller = new Traveller();
Passenger staff = new Staff();

Console.WriteLine(passenger.GetPassengerType());
Console.WriteLine(traveller.GetPassengerType());
Console.WriteLine(staff.GetPassengerType());


//TP1.Question13.c
passenger.BirthDate = new DateTime(2020,6,2);
//passenger.GetAge(passenger);
Console.WriteLine(passenger.GetAge);
 int age = 0;
//passenger.GetAge(new DateTime(2020, 6, 2), ref age);
Console.WriteLine(age);



//TP2 
Flight f=new Flight();
Plane pl = new Plane(PlaneType.Airbus, 500, DateTime.Now);

FlightService sf = new FlightService();
//sf.Flights = TestData.listFlights;
foreach (var flight in sf.GetFlightDates("Paris"))
{
    Console.WriteLine("Les dates sont");
    Console.WriteLine(flight);

};
foreach (var flight in sf.getFlightDates2("Paris"))
{
    Console.WriteLine("Les dates sont");
    Console.WriteLine(flight);

};
    Console.WriteLine("GetFlightFiltré");
    sf.GetFlights("Destination", "Paris");
    Console.WriteLine("Details de l'avion");
    sf.ShowFlightDetails(pl);
    Console.WriteLine(sf.GetDurationAverage("Madrid"));
    Console.WriteLine("Les vols ordonnés :");
foreach (var flight in sf.SortFlights())
{

    Console.WriteLine(flight);
}

    Console.WriteLine("Les Top 3 Travellers");

foreach (var fl in sf.GetThreeOlderTravellers(f))
{
    Console.WriteLine(f);
}
Console.WriteLine("Les vols par Destination  :");

    sf.ShowGroupedFlights(f);
   


