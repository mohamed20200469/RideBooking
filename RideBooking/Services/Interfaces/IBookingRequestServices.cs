using RideBooking.DTOs;

namespace RideBooking.Services.Interfaces
{
    public interface IBookingRequestServices
    {
        public IEnumerable<VehicleReadDTO> CreateBookingRequest(BookingRequestWriteDTO bookingRequestWriteDTO);
    }
}
