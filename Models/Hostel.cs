using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Models
{
    public class Hostel
    {
        [Key]
        public int ID { get; set; }

        public string HostelName { get; set; }

        public string HostelAddress { get; set; }

        public string HostelLocation { get; set; }

        public string HostelType { get; set; }

        public int HostelNumberOfRooms { get; set; }

        public string HostelDescription { get; set; }

        public Boolean VacantRoom { get; set; }

        public string HostelSlug { get; set; }

        public double RentPerRoom { get; set; }

        public DateTime CreatedHostel { get; set; }
    }
}
