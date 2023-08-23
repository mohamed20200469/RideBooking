using AutoMapper;
using RideBooking.DAL.Interfaces;
using RideBooking.DTOs;
using RideBooking.Models;
using RideBooking.Services.Interfaces;

namespace RideBooking.Services
{
    public class RideServices : IRideServices
    {
        private readonly IMapper _mapper;
        private readonly IRideDAL _rideDAL;
        private readonly IBookingRequestDAL _bookingRequestDAL;
        private readonly IVehicleDAL _vehicleDAL;

        public RideServices(IMapper mapper,
            IRideDAL rideDAL,
            IBookingRequestDAL bookingRequestDAL,
            IVehicleDAL vehicleDAL)
        {
            _mapper = mapper;
            _rideDAL = rideDAL;
            _bookingRequestDAL = bookingRequestDAL;
            _vehicleDAL = vehicleDAL;
        }

        public RideReadDTO? CreateRide(RideWriteDTO rideWriteDTO)
        {
            var ride = _mapper.Map<Ride>(rideWriteDTO);
            var bookingRequest = _bookingRequestDAL.GetBookingRequest(rideWriteDTO.bookingRequestId);
            if (bookingRequest != null)
            {
                ride.dateTimeStart = DateTime.Now;
                ride.fare = _vehicleDAL.GetVehicle((int)bookingRequest.vehicleId).fareByKm * ride.distance;
                ride.nameOfPassenger = bookingRequest.userName;
                _rideDAL.CreateRide(ride);
                return _mapper.Map<RideReadDTO>(ride);
            }
            return null;
        }

        public RideReadDTO? EndRide(int rideId, string dropoffLocation)
        {
            var ride = _rideDAL.GetRide(rideId);
            if (ride!=null)
            {
                _rideDAL.EndRide(rideId, dropoffLocation);
                return _mapper.Map<RideReadDTO>(ride);
            }
            return null;
        }

        public bool DeleteRide(int rideId)
        {
            return _rideDAL.DeleteRide(rideId);
        }

        public IEnumerable<RideReadDTO> GetAllRides()
        {
            var rides = _rideDAL.GetRides();
            return _mapper.Map<IEnumerable<RideReadDTO>>(rides);
        }

        public RideReadDTO? GetRide(int rideId)
        {
            var ride = _rideDAL.GetRide(rideId);
            if (ride == null) return null;
            return _mapper.Map<RideReadDTO>(ride);
        }

        public bool UpdateRideRate(int rideId, int rate)
        {
            return _rideDAL.UpdateRideRate(rideId, rate);
        }
    }
}
