using RideBooking.Models;

namespace RideBooking.DAL.Interfaces
{
    public interface IRideDAL
    {
        public void CreateRide(Ride ride);
        public IEnumerable<Ride> GetRides();
        public Ride? GetRide(int id);
        public bool DeleteRide(int id);
        public bool UpdateRideRate(int rideId, int rate);
        public bool EndRide(int rideId, string dropoffLocation);
    }
}
