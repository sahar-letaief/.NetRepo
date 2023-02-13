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
    }
}
