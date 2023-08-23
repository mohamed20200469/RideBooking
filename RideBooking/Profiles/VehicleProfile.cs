using AutoMapper;
using RideBooking.DTOs;
using RideBooking.Models;

namespace RideBooking.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<VehicleWriteDTO, Vehicle>();
            CreateMap<Vehicle, VehicleReadDTO>();
        }
    }
}
