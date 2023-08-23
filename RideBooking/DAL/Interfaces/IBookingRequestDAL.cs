using RideBooking.Models;

namespace RideBooking.DAL.Interfaces
{
    public interface IBookingRequestDAL
    {
        public BookingRequest? GetBookingRequest(int id);
        public IEnumerable<BookingRequest> GetAllBookingRequests();
        public void CreateRequest(BookingRequest request);
        public bool UpdateRequest(BookingRequest request, bool state);
        public void DeleteRequest(BookingRequest request);
        public bool AddVehicleId(int bookingRequestId, int vehicleId);
    }
}
