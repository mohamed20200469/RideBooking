using RideBooking.Models;
using System.ComponentModel.DataAnnotations;

namespace RideBooking.DTOs
{
    public class RideWriteDTO
    {
        public int bookingRequestId { get; set; }
        public float distance { get; set; }
        public int numberOfPassengers { get; set; }
    }
}
