using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
    /// <summary>
    /// the login dto that interfaces with the user input and the user database
    /// </summary>
    /// <returns></returns>
    public class AddHostelDto
    {
        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(50, ErrorMessage = "Hostel name cannot be longer than 50 characters")]
        public string HostelName { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Hostel address cannot be longer than 100 characters")]
        public string HostelAddress { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(50, ErrorMessage = "Hostel location cannot be longer than 50 characters")]
        public string HostelLocation { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string HostelType { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [Range(1, 100)]
        public int HostelNumberOfRooms { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string HostelDescription { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        public Boolean VacantRoom { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [DataType(DataType.MultilineText)]
        [StringLength(200)]
        public string HostelSlug { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        public double RentPerRoom { get; set; }

        /// <summary>
        /// the login dto that interfaces with the user input and the user database
        /// </summary>
        /// <returns></returns>
        [DataType(DataType.Date)]
        public DateTime CreatedHostel { get; set; }
    }
}
