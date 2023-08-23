using RideBooking.DAL.Interfaces;
using RideBooking.Models;

namespace RideBooking.DAL
{
    public class RideDAL : IRideDAL
    {
        private readonly AppDbContext _db;

        public RideDAL(AppDbContext db)
        {
            _db = db;
        }
        public void CreateRide(Ride ride)
        {
            _db.Rides.Add(ride);
            _db.SaveChanges();
        }

        public bool DeleteRide(int id)
        {
            var ride = _db.Rides.FirstOrDefault(x => x.id == id);
            if(ride != null) 
            {
                _db.Rides.Remove(ride);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public Ride? GetRide(int id)
        {
            var ride = _db.Rides.FirstOrDefault(x => x.id == id);
            if(ride != null)
            {
                return ride;
            }
            return null;
        }

        public IEnumerable<Ride> GetRides()
        {
            return _db.Rides.ToList();
        }

        public bool UpdateRideRate(int rideId, int rate)
        {
            var ride = _db.Rides.FirstOrDefault(x => x.id == rideId);
            if (rate > 0 && rate < 6 && ride != null)
            {
                ride.rate = rate;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EndRide(int rideId, string dropoffLocation)
        {
            var ride = _db.Rides.FirstOrDefault(x => x.id == rideId);
            if (ride != null)
            {
                ride.ended = true;
                ride.dateTimeEnd = DateTime.Now;
                ride.dropoffLocation = dropoffLocation;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
