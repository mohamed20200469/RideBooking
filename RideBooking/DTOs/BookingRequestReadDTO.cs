using System.ComponentModel.DataAnnotations;

namespace RideBooking.DTOs
{
    public class BookingRequestReadDTO
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string pickupLocation { get; set; }
        public bool accepted { get; set; }
        public int vehicleId { get; set; }
    }
}
