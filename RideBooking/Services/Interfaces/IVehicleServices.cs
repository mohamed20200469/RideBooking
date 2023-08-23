using RideBooking.DTOs;

namespace RideBooking.Services.Interfaces
{
    public interface IVehicleServices
    {
        public bool AddVehicle(VehicleWriteDTO vehicleWriteDTO);
        public VehicleReadDTO GetVehicle(int id);
        public IEnumerable<VehicleReadDTO> GetVehicles();
    }
}
