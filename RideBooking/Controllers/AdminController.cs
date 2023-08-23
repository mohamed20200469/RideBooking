using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideBooking.DTOs;
using RideBooking.Models;
using RideBooking.Services.Interfaces;

namespace RideBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehicleServices _vehicleServices;
        private readonly IDriverServices _driverServices;
        private readonly IRideServices _rideServices;

        public AdminController(IMapper mapper,
            IVehicleServices vehicleServices,
            IDriverServices driverServices,
            IRideServices rideServices)
        {
            _mapper = mapper;
            _vehicleServices = vehicleServices;
            _driverServices = driverServices;
            _rideServices = rideServices;
            
        }

        [HttpGet("GetAllRides")]
        public ActionResult<IEnumerable<RideReadDTO>> GetAllRideRequests()
        {
            return Ok(_rideServices.GetAllRides());
        }

        [HttpGet("GetAllDrivers")]
        public ActionResult<IEnumerable<DriverReadDTO>> GetAllDrivers()
        {
            return Ok(_driverServices.GetAllDrivers());
        }

        [HttpGet("GetAllVehicles")]
        public ActionResult<IEnumerable<VehicleReadDTO>> GetVehicles()
        {
            return Ok(_vehicleServices.GetVehicles());
        }

        [HttpPost("AddVehicle")]
        public ActionResult<VehicleReadDTO?> AddVehicle(VehicleWriteDTO vehicleWriteDTO)
        {
            var vehicle = _mapper.Map<Vehicle>(vehicleWriteDTO);
            if (_vehicleServices.AddVehicle(vehicleWriteDTO))
            {
                return Ok(_mapper.Map<VehicleReadDTO>(vehicle));
            }
            return BadRequest(null);
        }

        [Authorize]
        [HttpPost("AddDriver")]
        public ActionResult<DriverReadDTO?> AddDriver(DriverWriteDTO driverWriteDTO)
        {
            var driver = _driverServices.AddDriver(driverWriteDTO);
            if (driver != null)
            {
                return Ok(driver);
            }
            return BadRequest();
        }
    }
}
