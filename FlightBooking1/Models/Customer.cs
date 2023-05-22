using System.ComponentModel.DataAnnotations;

namespace FlightBooking1.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(20)]
        public String FirstName { get; set; }

        [StringLength(20)]
        public String LastName { get; set; }

        public String? Address { get; set; }
        public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bắt buộc điền Email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }




    }
}
