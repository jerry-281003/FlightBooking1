using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBooking1.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationsID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [DataType(DataType.Date)]
        [ForeignKey("FlightSchedule")]
        public DateTime StartDay { get; set; }

        [ForeignKey("Flight")]
        public DateTime FlightID { get; set; }
    }
}
