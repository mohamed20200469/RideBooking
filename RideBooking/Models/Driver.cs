using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RideBooking.Models
{
    public class Driver
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string name { get; set; }
    }
}
