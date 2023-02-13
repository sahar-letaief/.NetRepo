using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    internal class FlightService : IFlightService
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
    }
}
