using AutoMapper;
using RideBooking.DTOs;
using RideBooking.Models;

namespace RideBooking.Profiles
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<RideWriteDTO, Ride>();
            CreateMap<Ride, RideReadDTO>();
        }
    }
}
