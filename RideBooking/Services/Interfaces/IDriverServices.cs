using RideBooking.DTOs;

namespace RideBooking.Services.Interfaces
{
    public interface IDriverServices
    {
        public DriverReadDTO GetDriver(int driverId);
        public IEnumerable<DriverReadDTO> GetAllDrivers();
        public DriverReadDTO? AddDriver(DriverWriteDTO driverWriteDTO);
        public IEnumerable<BookingRequestReadDTO> GetAllBookingRequests();
        public BookingRequestReadDTO AcceptBookingRequets(int vehicleId, int bookingRequestId);
    }
}
