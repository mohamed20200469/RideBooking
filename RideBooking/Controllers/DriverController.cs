using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RideBooking.DTOs;
using RideBooking.Models;
using RideBooking.Services.Interfaces;

namespace RideBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Driver")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverServices _driverServices;
        private readonly IVehicleServices _vehicleServices;
        private readonly IMapper _mapper;
        private readonly IRideServices _rideServices;

        public DriverController(IDriverServices driverServices,
            IVehicleServices vehicleServices, IMapper mapper,
            IRideServices rideServices)
        {
            _driverServices = driverServices;
            _vehicleServices = vehicleServices;
            _mapper = mapper;
            _rideServices = rideServices;
        }

        [HttpGet("GetAllBookingRequests")]
        public ActionResult<IEnumerable<BookingRequestReadDTO>> GetAllBookingRequests()
        {
            var bookingRequests = _driverServices.GetAllBookingRequests();
            return Ok(bookingRequests);
        }

        [HttpPatch("AcceptBookingRequest")]
        public ActionResult<BookingRequestReadDTO> AcceptBookingRequest(int vehicleId, int bookingRequestId)
        {
            var bookingRequestReadDTO = _driverServices.AcceptBookingRequets(vehicleId, bookingRequestId);
            if(bookingRequestReadDTO.accepted == true) return Ok(bookingRequestReadDTO);
            return BadRequest(bookingRequestReadDTO);
        }

        [HttpPost("StartRide")]
        public ActionResult<RideReadDTO> StartRide(RideWriteDTO rideWriteDTO)
        {
            var rideReadDTO = _rideServices.CreateRide(rideWriteDTO);
            if (rideReadDTO != null)
            {
                return Ok(rideReadDTO);
            }
            return BadRequest();
        }

        [HttpPatch("EndRide")]
        public ActionResult<RideReadDTO> EndRide(int rideId, string dropoffLocation)
        {
            var ride = _rideServices.EndRide(rideId, dropoffLocation);
            if (ride != null)
            {
                return Ok(ride);
            }
            return BadRequest();
        }
    }
}
