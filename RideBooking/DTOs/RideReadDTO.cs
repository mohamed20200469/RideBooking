using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RideBooking.DTOs
{
    public class RideReadDTO
    {
        public int id { get; set; }
        public int bookingRequestId { get; set; }
        public float distance { get; set; }
        public int rate { get; set; }
        public string nameOfPassenger { get; set; }
        public int numberOfPassengers { get; set; }
        public float fare { get; set; }
        public DateTime dateTimeStart { get; set; }
        public DateTime dateTimeEnd { get; set; }
        public string dropoffLocation { get; set; }
        public bool ended { get; set; }
    }
}
