using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
    public class PhotosForDetailedDto
    {
        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        public int Id { get; set; }

        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        public string Url { get; set; }

        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        public bool IsMain { get; set; }
  }
}
