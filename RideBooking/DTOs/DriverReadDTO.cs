using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RideBooking.DTOs
{
    public class DriverReadDTO
    {
        public int id { get; set; }
        public int age { get; set; }
        public string name { get; set; } 
    }
}
