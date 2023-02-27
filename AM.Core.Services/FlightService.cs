using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class FlightService:IFlightService
    {
        public IList<Flight> Flights { get; set; }

        //TP2.Q4
        public IList<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> dates = new List<DateTime>();
            //foreach(var flight in Flights)
            //{
            //    if(flight.Destination == destination)
            //    {
            //        dates.Add(flight.FlightDate); 
            //    }  
            //}
            //return dates;

            //TP2.Q6
            //1er méthode
            return (from flight in Flights
            where flight.Destination == destination
            select flight.FlightDate).ToList();

            //2ème méthode
            return Flights.Where(flight => flight.Destination == destination)
                          .Select(flight => flight.FlightDate)
                          .ToList();
        }
        //TP2.Q5
        public List<Flight> GetFlights(string filterType, string filterValue)
        {

            //switch (filterType)
            //{
            //    case "Destination":
            //        return Flights.Where(flight => flight.Destination == filterValue).ToList();
            //    case "Departure":
            //        return Flights.Where(flight => flight.Departure == filterValue).ToList();
            //    case "EffectiveArrival":
            //        return Flights.Where(flight => flight.EffectiveArrival.ToString() == filterValue).ToList();
            //    case "EstimatedDuration":
            //        return Flights.Where(flight => flight.EstimatedDuration.ToString() == filterValue).ToList();
            //    case "FlightDate":
            //        return Flights.Where(flight => flight.FlightDate.ToString()== filterValue).ToList();
            //    case "FlightId":
            //        return Flights.Where(flight => flight.FlightId.ToString() == filterValue).ToList();
            //    default: return new List<Flight>();
            //}

            var flights = new List<Flight>();
            foreach (Flight f in Flights)
            {
                var prop = f.GetType().GetProperty(filterType);
                if (prop != null)
                {
                    var val = (String)prop.GetValue(f);
                    if (filterValue.Equals(val))
                    {
                        flights.Add(f);
                    }
                }
            }
            return flights;

        }

        

        //TP2 Q7
        public void ShowFlightDetails(Plane p)
        {
            var req = Flights.Where(f => f.MyPlane.PlaneId == p.PlaneId);
            foreach (var flight in req)
            {
                Console.WriteLine(flight.FlightDate + "" + flight.Destination);
            }
            //2eme methode
            var result = from f in Flights
                         where f.MyPlane.PlaneId == p.PlaneId
                         select new { f.FlightDate, f.Destination };
            foreach(var obj in result)
            {
                Console.WriteLine("Date: {} -- Dest: {}"
                    , obj.FlightDate, obj.Destination);
            }
        }

        //TP2 Q8
        public int GetWeeklyFlightNumber(DateTime date)
        {
           /* return (Flights
                .Where(f => (f.FlightDate - date).TotalDays < 7 
                && (f.FlightDate - date).TotalDays >= 0)
                .Count();*/

            //2eme methode 

           /* return Flights
                .Where(f => f.FlightDate >= date && f.FlightDate < date.AddDays(7))
                .Count();*/

            //3eme methode
            return (from f in Flights
                   where f.FlightDate >= date && f.FlightDate < date.AddDays(7)
                   select f).Count();

        }

        //TP2 Q9
        public double GetDurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
               .Select(f => f.EstimatedDuration).Average();
        }
 
        //TP2 Q10
        public IList<Flight> SortFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration)
                .ToList();
        }

        //TP2 Q11
        public IList<Passenger> GetThreeOlderTravellers(Flight f)
        {
            
            /*return f.Passengers
                .OrderByDescending(pass => pass.Age)
                .Take(3).ToList();*/
            //2eme methode 
            return f.Passengers
                .OfType<Traveller>()
                .OrderBy(pass => pass.BirthDate)
                .Take(3).ToList<Passenger>();
        }
        //TP2 Q12
        public void ShowGroupedFlights()
        {
            IEnumerable<IGrouping<string,Flight>> result = Flights
                .GroupBy(f => f.Destination);
            foreach(var grp in result)
            {
                Console.WriteLine(grp.Key);
                foreach(var flight in grp)
                {
                    Console.WriteLine(flight);
                }
            }
            
        }

        //TP2 Q13 b
        public Passenger GetSeniorPassenger(IFlightService.GetScore meth)
        {
            return Flights.SelectMany(f => f.Passengers)
                .MaxBy(p => meth(p));
        }
    }

    }

