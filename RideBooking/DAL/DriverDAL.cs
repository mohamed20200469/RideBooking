using RideBooking.DAL.Interfaces;
using RideBooking.Models;

namespace RideBooking.DAL
{
    public class DriverDAL : IDriverDAL
    {
        private readonly AppDbContext _db;

        public DriverDAL(AppDbContext db)
        {
            _db = db;
        }
        public void CreateDriver(Driver driver)
        {
            _db.Drivers.Add(driver);
            _db.SaveChanges();
        }

        public bool DeleteDriver(int id)
        {
            var driver = _db.Drivers.FirstOrDefault(x => x.id == id);
            if (driver != null)
            {
                _db.Drivers.Remove(driver);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return _db.Drivers.ToList();
        }

        public Driver? GetDriver(int id)
        {
            var driver = _db.Drivers.FirstOrDefault(x =>x.id == id);
            if(driver != null)
            {
                return driver;
            }
            return null;
        }
    }
}
