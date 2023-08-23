using RideBooking.Models;

namespace RideBooking.DAL.Interfaces
{
    public interface IDriverDAL
    {
        public void CreateDriver(Driver driver);
        public Driver? GetDriver(int id);
        public bool DeleteDriver(int id);
        public IEnumerable<Driver> GetAllDrivers();
    }
}
