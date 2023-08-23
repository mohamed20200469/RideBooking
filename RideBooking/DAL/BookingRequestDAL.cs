using RideBooking.DAL.Interfaces;
using RideBooking.Models;

namespace RideBooking.DAL
{
    public class BookingRequestDAL : IBookingRequestDAL
    {
        private readonly AppDbContext _db;

        public BookingRequestDAL(AppDbContext db) 
        {
            _db = db;
        }
        public void CreateRequest(BookingRequest request)
        {
            _db.BookingRequests.Add(request);
            _db.SaveChanges();
        }

        public void DeleteRequest(BookingRequest request)
        {
            _db.BookingRequests.Remove(request);
            _db.SaveChanges();
        }

        public IEnumerable<BookingRequest> GetAllBookingRequests()
        {
            return _db.BookingRequests.ToList();
        }

        public BookingRequest? GetBookingRequest(int id)
        {
                return _db.BookingRequests.FirstOrDefault(x => x.id == id);
        }

        public bool UpdateRequest(BookingRequest request, bool state)
        {
            var _request = _db.BookingRequests.FirstOrDefault(x => x.id == request.id);
            if (_request != null)
            {
                _request.accepted = state;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddVehicleId(int bookingRequestId, int vehicleId)
        {
            var vehicle = _db.Vehicles.FirstOrDefault(c => c.id == vehicleId);
            var bookingRequest = _db.BookingRequests.FirstOrDefault(x => x.id == bookingRequestId);
            if (vehicle != null && bookingRequest != null)
            {
                bookingRequest.vehicleId = vehicleId;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
