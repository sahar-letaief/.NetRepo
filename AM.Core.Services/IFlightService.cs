using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService
    {
        IList<DateTime> GetFlightDates(String destination);
        /// <summary>
        /// affiche la date et les destinations d'un avion donné
        /// </summary>
        /// <param name="p"></param>
        public void ShowFlightDetails(Plane p);
        /// <summary>
        /// retourne le nombre de vols par semaine 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetWeeklyFlightNumber(DateTime date);
        /// <summary>
        /// retourne la moyenne de durées estimees pour une destination donnée
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public double GetDurationAverage(String destination);
        /// <summary>
        /// retourne la liste des vols avec un ordre décroissant selon les durees estimées
        /// </summary>
        /// <returns></returns>
        public IList<Flight> SortFlights();
        public IList<Passenger> GetThreeOlderTravellers(Flight f);
        public void ShowGroupedFlights();

        //TP2 Q13 a
        public delegate double GetScore(Passenger p);

        public Passenger GetSeniorPassenger(GetScore meth);

    }
}
