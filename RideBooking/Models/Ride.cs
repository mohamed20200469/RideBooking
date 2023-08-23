using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RideBooking.Models
{
    public class Ride
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("bookingRequest")]
        public int? bookingRequestId { get; set; }
        public BookingRequest? bookingRequest { get; set; }
        [Required]
        public float distance { get; set; }
        [Required]
        public string nameOfPassenger { get; set; }
        public int numberOfPassengers { get; set; }
        public float fare { get; set; }
        public int rate { get; set; }
        public DateTime dateTimeStart { get; set; }
        public DateTime? dateTimeEnd { get; set; }
        public string? dropoffLocation { get; set; }
        public bool ended { get; set; } = false;
    }
}
