using System.ComponentModel.DataAnnotations;

namespace FlightBooking1.Models
{
    public class Plane
    {
        [Key]
        public int PlaneID { get; set; }
        public string TypeOfPlane { get; set; }

    }
}
