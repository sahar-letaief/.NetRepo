using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    internal interface IFlightService
    {
        IList<DateTime> GetFlightDates(String destionation);
        IList<Flight> GetFlights(String filterType, String filterValue);
        public IList<DateTime> getFlightDates2(string destination);
        public void ShowFlightDetails(Plane p);
        public int GetWeeklyFlightNumber(DateTime dateChoisie);
        public double GetDurationAverage(String des);
        public IList<Flight> SortFlights();
        public IList<Traveller> GetThreeOlderTravellers(Flight f);
        public IList<Flight> ShowGroupedFlights(Flight f);

        public IList<Traveller> GetSeniorPassenger(Flight f);
    }
}
