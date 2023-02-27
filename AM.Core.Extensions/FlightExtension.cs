using AM.Core.Domain;
namespace AM.Core.Extensions
 
{
    public static class FlightExtension
    {
        public static int GetDelay(this Flight f)
        {
            var diff = (f.EffectiveArrival - f.FlightDate).Minutes;
            return diff-f.EstimatedDuration;
        }
    }
}