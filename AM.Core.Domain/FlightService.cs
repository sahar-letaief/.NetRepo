using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }

        public IList<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach(var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    dates.Add(flight.FlightDate);
                }
            }
            return dates;
        }

        //TP2 Q5

        /* public IList<Flight> GetFlights(String filterType, String filterValue)
         {
             List<Flight> list = new List<Flight>();
             switch (filterType)
             {
                 case "Destination":
                     return Flights.Where(flight=>flight.Destination== filterValue).ToList();
                 case "Departure":
                     return Flights.Where(flight => flight.Departure == filterValue).ToList();
                 case "EffectiveArrival":
                     return Flights.Where(flight => flight.EffectiveArrival.ToString() == filterValue).ToList();
                 case "EsimatedDuration":
                     return Flights.Where(flight => flight.EstimatedDuration.ToString() == filterValue).ToList();
                 case "FlightDate":
                     return Flights.Where(flight => flight.FlightDate.ToString() == filterValue).ToList();
                 case "FlightId":
                     return Flights.Where(flight => flight.FlightId.ToString() == filterValue).ToList();
                 default : return new List<Flight>();
             }

          }*/


        //TP2 Q6 (2eme méthode)
        public IList<DateTime> getFlightDates2(string destination)
        {
            return( Flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate).ToList());
        }
        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
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
            var req = Flights.Where(f => f.MyPlane == p);
            foreach (var flight in req)
            {
                Console.WriteLine(flight.FlightDate + "" + flight.Destination);
            }

        }

        //TP2 Q8
        public int GetWeeklyFlightNumber(DateTime dateChoisie)
        {
            return (Flights
                 .Where(f => (f.FlightDate - dateChoisie).TotalDays < 7 && (f.FlightDate - dateChoisie).TotalDays > 0)
                 .Select(f => f)).Count();
        }

        //TP2 Q9
        public double GetDurationAverage(String des)
        {
            return (Flights.Where(f => f.Destination == des).Select(f => f.EstimatedDuration)).Average();
        }

        //TP2 Q10
        public IList<Flight> SortFlights()
        {
            //var flights = new List<Flight>();

            return Flights.OrderByDescending(f=>f.Destination).ToList();
        }

        //TP2 Q11
        public IList<Traveller> GetThreeOlderTravellers(Flight f)
        {
            Passenger pass = new Passenger();
            return f.Passengers.OfType<Traveller>().OrderBy(pass=>pass.BirthDate)
                .Take(3).ToList();
        }

        //TP2 Q12
        public IList<Flight> ShowGroupedFlights(Flight f)
        {
            return ((IList<Flight>)Flights.GroupBy(f => f.Destination).ToList());
        }

        //TP2 Q13
        public IList<Traveller> GetSeniorPassenger(Flight f)
        {
           
            return (f.Passengers.OfType<Traveller>().OrderBy(p => p.BirthDate).Take(1).ToList());
        }

    }
  
}
