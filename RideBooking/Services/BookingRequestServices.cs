using AutoMapper;
using RideBooking.DAL.Interfaces;
using RideBooking.DTOs;
using RideBooking.Models;
using RideBooking.Services.Interfaces;

namespace RideBooking.Services
{
    public class BookingRequestServices : IBookingRequestServices
    {
        private readonly IMapper _mapper;
        private readonly IBookingRequestDAL _bookingRequestDAL;
        private readonly IVehicleDAL _vehicleDAL;

        public BookingRequestServices(IMapper mapper,
            IBookingRequestDAL bookingRequestDAL,
            IVehicleDAL vehicleDAL) 
        {
            _mapper = mapper;
            _bookingRequestDAL = bookingRequestDAL;
            _vehicleDAL = vehicleDAL;
        }

        public IEnumerable<VehicleReadDTO> CreateBookingRequest(BookingRequestWriteDTO bookingRequestWriteDTO)
        {
            var availableVehicles = _vehicleDAL.GetAllVehicles();
            var bookingRequest = _mapper.Map<BookingRequest>(bookingRequestWriteDTO);
            _bookingRequestDAL.CreateRequest(bookingRequest);
            return _mapper.Map<IEnumerable<VehicleReadDTO>>(availableVehicles);
        }
    }
}
