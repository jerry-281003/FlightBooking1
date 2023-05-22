using System.ComponentModel.DataAnnotations;

namespace FlightBooking1.Models
{
    public class Flight
    {
        public String FlightID { get; set; }
        public string StarAddress { get; set; }
        public string StarCity { get; set; }
        public string EndCity { get; set; }
        [DataType(DataType.Time)]
        public string DepartureTime { get; set; }
        [DataType(DataType.Time)]
        public string ArrivalTime { get; set; }

        public int Price { get; set; }
    }
}
