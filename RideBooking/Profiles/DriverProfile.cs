using AutoMapper;
using RideBooking.DTOs;
using RideBooking.Models;

namespace RideBooking.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverReadDTO>();
            CreateMap<DriverWriteDTO, Driver>();
        }
    }
}
