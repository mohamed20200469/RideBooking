using AutoMapper;
using RideBooking.DAL;
using RideBooking.DAL.Interfaces;
using RideBooking.DTOs;
using RideBooking.Models;
using RideBooking.Services.Interfaces;
using System.Collections.Generic;

namespace RideBooking.Services
{
    public class DriverServices : IDriverServices
    {
        private readonly IDriverDAL _driverDAL;
        private readonly IVehicleDAL _vehicleDAL;
        private readonly IBookingRequestDAL _bookingRequestDAL;
        private readonly IRideDAL _rideDAL;
        private readonly IMapper _mapper;

        public DriverServices( IDriverDAL driverDAL,
            IVehicleDAL vehicleDAL, 
            IBookingRequestDAL bookingRequestDAL,
            IRideDAL rideDAL, IMapper mapper)
        {
            _driverDAL = driverDAL;
            _vehicleDAL = vehicleDAL;
            _bookingRequestDAL = bookingRequestDAL;
            _rideDAL = rideDAL;
            _mapper = mapper;
        }

        public BookingRequestReadDTO AcceptBookingRequets(int vehicleId, int bookingRequestId)
        {
            var vehicle = _vehicleDAL.GetVehicle(vehicleId);
            var bookingRequest = _bookingRequestDAL.GetBookingRequest(bookingRequestId);
            if (vehicle != null && bookingRequest != null && bookingRequest.accepted != true)
            {
                _bookingRequestDAL.AddVehicleId(bookingRequestId, vehicleId);
                _bookingRequestDAL.UpdateRequest(bookingRequest, true);
            }
            return _mapper.Map<BookingRequestReadDTO>(bookingRequest);
        }

        public DriverReadDTO AddDriver(DriverWriteDTO driverWriteDTO)
        {
            var driver = _mapper.Map<Driver>(driverWriteDTO);
            _driverDAL.CreateDriver(driver);
            return _mapper.Map<DriverReadDTO>(driver);
        }

        public IEnumerable<BookingRequestReadDTO> GetAllBookingRequests()
        {
            return _mapper.Map<IEnumerable<BookingRequestReadDTO>>(_bookingRequestDAL.GetAllBookingRequests());
        }

        public IEnumerable<DriverReadDTO> GetAllDrivers() 
        {
            var drivers = _mapper.Map<IEnumerable<DriverReadDTO>>(_driverDAL.GetAllDrivers());
            return drivers;
        }

        public DriverReadDTO GetDriver(int driverId) 
        {
            var driver = _driverDAL.GetDriver(driverId);
            return _mapper.Map<DriverReadDTO>(driver);
        }


    }
}
