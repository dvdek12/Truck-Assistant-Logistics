using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TruckAssistant.Common;

namespace TruckAssistant.Models
{
    public class Trip
    {
        public Trip()
        {
            
        }
        
        public int Id { get; set; }


        [Required]
        [ValidStartDate]
        public DateTime? StartDate { get; set; }


        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public DateTime? CreateDate { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Range { get; set; }


        public string? Description { get; set; }

        [ForeignKey("Truck")]
        public int? TruckId { get; set; }

        public virtual Truck? Truck { get; set; }

        


    }
}
