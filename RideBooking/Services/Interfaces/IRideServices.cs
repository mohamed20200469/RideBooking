using AutoMapper;
using RideBooking.DAL.Interfaces;
using RideBooking.DTOs;
using RideBooking.Models;

namespace RideBooking.Services.Interfaces
{
    public interface IRideServices
    {
        public RideReadDTO? CreateRide(RideWriteDTO ride);
        public bool UpdateRideRate(int rideId, int rate);
        public RideReadDTO? GetRide(int rideId);
        public IEnumerable<RideReadDTO> GetAllRides();
        public bool DeleteRide(int rideId);
        public RideReadDTO? EndRide(int rideId, string dropoffLocation);
    }
}
