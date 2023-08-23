using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RideBooking.Models
{
    public class BookingRequest
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string pickupLocation { get; set; }
        public bool accepted { get; set; } = false;
        [ForeignKey("vehicle")]
        public int? vehicleId { get; set; }
        public Vehicle? vehicle { get; set; }

    }
}
