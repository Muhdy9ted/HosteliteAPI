using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
    public class AddHostelDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Hostel name cannot be longer than 50 characters")]
        public string HostelName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Hostel address cannot be longer than 100 characters")]
        public string HostelAddress { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Hostel location cannot be longer than 50 characters")]
        public string HostelLocation { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string HostelType { get; set; }

        [Required]
        [Range(1, 100)]
        public int HostelNumberOfRooms { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string HostelDescription { get; set; }

        [Required]
        public Boolean VacantRoom { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string HostelSlug { get; set; }

        [Required]
        public double RentPerRoom { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedHostel { get; set; }
    }
}
