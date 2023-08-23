using AutoMapper;
using RideBooking.DAL.Interfaces;
using RideBooking.DTOs;
using RideBooking.Models;
using RideBooking.Services.Interfaces;

namespace RideBooking.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly IMapper _mapper;
        private readonly IVehicleDAL _vehicleDAL;
        private readonly IDriverDAL _driverDAL;

        public VehicleServices(IMapper mapper,
            IVehicleDAL vehicleDAL,
            IDriverDAL driverDAL)
        {
            _mapper = mapper;
            _vehicleDAL = vehicleDAL;
            _driverDAL = driverDAL;
        }

        public bool AddVehicle(VehicleWriteDTO vehicleWriteDTO)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleWriteDTO);
            vehicle.driver = _driverDAL.GetDriver(vehicle.driverId);
            if (vehicle.driver != null && _vehicleDAL.CreateVehicle(vehicle))
            {
            return true;
            }
            return false;
        }

        public VehicleReadDTO GetVehicle(int id)
        {
            var vehicle = _vehicleDAL.GetVehicle(id);
            return _mapper.Map<VehicleReadDTO>(vehicle);
        }

        public IEnumerable<VehicleReadDTO> GetVehicles()
        {
            return _mapper.Map<IEnumerable<VehicleReadDTO>>(_vehicleDAL.GetAllVehicles());
        }
    }
}
