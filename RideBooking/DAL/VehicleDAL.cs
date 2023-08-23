using RideBooking.DAL.Interfaces;
using RideBooking.Models;

namespace RideBooking.DAL
{
    public class VehicleDAL : IVehicleDAL
    {
        private readonly AppDbContext _db;

        public VehicleDAL(AppDbContext db) 
        {
            _db = db;
        }
        public bool CreateVehicle(Vehicle vehicle)
        {
            _db.Vehicles.Add(vehicle);
            if(_db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteVehicle(int id)
        {
            var vehicle = _db.Vehicles.FirstOrDefault(x => x.id == id);

            if (vehicle != null)
            {
                _db.Vehicles.Remove(vehicle);
                _db.SaveChanges();
                return true;
            }
            return false;
            
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _db.Vehicles.ToList();
        }

        public Vehicle? GetVehicle(int id)
        {
            var vehicle = _db.Vehicles.FirstOrDefault(x => x.id == id);

            if (vehicle != null)
            {
                return vehicle;
            }
            return null;
        }
    }
}
