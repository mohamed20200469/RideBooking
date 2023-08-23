﻿using RideBooking.Models;
using System.ComponentModel.DataAnnotations;

namespace RideBooking.DTOs
{
    public class VehicleReadDTO
    {
        public int id { get; set; }
        public VehicleType vehicleType { get; set; }
        public int capacity { get; set; }
        public float fareByKm { get; set; }
        public int modelYear { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public int maxSpeed { get; set; }
        public int driverId { get; set; }

    }
}
