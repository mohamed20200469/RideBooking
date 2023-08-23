using RideBooking.Models;

namespace RideBooking.DTOs
{
    public class VehicleWriteDTO
    {
        public VehicleType vehicleType { get; set; }
        public int driverId { get; set; }
        public int capacity { get; set; }
        public float fareByKm { get; set; }
        public int modelYear { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public int maxSpeed { get; set; }
    }
}
