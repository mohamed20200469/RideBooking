using AutoMapper;
using RideBooking.DTOs;
using RideBooking.Models;

namespace RideBooking.Profiles
{
    public class BookingRequestProfile : Profile
    {
        public BookingRequestProfile()
        {
            CreateMap<BookingRequest, BookingRequestReadDTO>();
            CreateMap<BookingRequestWriteDTO, BookingRequest>();
        }
    }
}
