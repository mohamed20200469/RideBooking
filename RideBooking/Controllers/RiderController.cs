using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RideBooking.DTOs;
using RideBooking.Services.Interfaces;
using System.Security.Claims;

namespace RideBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Rider")]
    public class RiderController : ControllerBase
    {
        private readonly IBookingRequestServices _bookingRequestServices;
        private readonly IMapper _mapper;
        private readonly IRideServices _rideServices;

        public RiderController(
            IBookingRequestServices bookingRequestServices,
            IMapper mapper, IRideServices rideServices)
        {
            _bookingRequestServices = bookingRequestServices;
            _mapper = mapper;
            _rideServices = rideServices;
        }

        [HttpPost("CreateBookingRequest")]
        public ActionResult<IEnumerable<VehicleReadDTO>> CreateBookingRequest(string pickupLocation)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claimsList = identity.Claims.ToList();
            var userName = claimsList.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            BookingRequestWriteDTO requestDTO = new BookingRequestWriteDTO();
            requestDTO.userName = userName;
            requestDTO.pickupLocation = pickupLocation;
            return Ok(_bookingRequestServices.CreateBookingRequest(requestDTO));
        }

        [HttpPatch("RateRide")]
        public ActionResult RateRide(int rideId, int rate)
        {
            var flag = _rideServices.UpdateRideRate(rideId, rate);
            if (flag)
            {
                return Ok("Ride rated");
            }
            return BadRequest("Ride rate unsuccesful, rate from 1 to 5");
        }
    }
}
