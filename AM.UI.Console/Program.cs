// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;

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


