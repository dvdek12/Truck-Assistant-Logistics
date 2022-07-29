using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TruckAssistant.Models
{
    public class Truck
    {
        public int Id { get; set; }

        [DisplayName("Truck Name")]
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string? Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string? Brand { get; set; }

        [DisplayName("Max. Velocity")]
        [Range(0,500)]
        [Required]
        public int Vmax { get; set; }

        [Required]
        [DisplayName("Break Length (min.)")]
        public int DriverBreaksLength { get; set; }

        [Required]
        [DisplayName("Break Interval (h.)")]
        public int DriverBreaksInterval { get; set; }
    }
}
