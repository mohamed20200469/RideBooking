using RideBooking.Models;

namespace RideBooking.DAL.Interfaces
{
    public interface IVehicleDAL
    {
        public bool CreateVehicle(Vehicle vehicle);
        public Vehicle? GetVehicle(int id);
        public bool DeleteVehicle(int id);
        public IEnumerable<Vehicle> GetAllVehicles();
    }
}
