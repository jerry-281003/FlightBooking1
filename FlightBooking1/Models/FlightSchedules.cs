using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBooking1.Models
{
    public class FlightSchedules
    {
        public String StartDay { get; set; }
        [Key]
        public String FlightID { get; set; }
        [ForeignKey("Plane")]
        public String PlaneID { get; set; }
        public String TypeOfPlane { get; set; }
    }
}
