using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RideBooking.Models
{
    public enum VehicleType
    {
        Car,
        Minivan,
        Bus
    }
    public class Vehicle
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("driver")]
        public int driverId { get; set; }
        public Driver driver { get; set; }
        [Required]
        public VehicleType vehicleType { get; set; }
        public int capacity { get; set; }
        [Required]
        public float fareByKm { get; set; }
        public int modelYear { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public int maxSpeed { get; set; }
        public bool availability { get; set; } = true;
    }
}
