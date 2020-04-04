using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Models
{
    public class landlord
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public User user { get; set; }

        //public string propertyName { get; set; }

        public DateTime dateJoined { get; set; }
       
        public landlord()
        {
            user = new User();
        }
    }
}
