using System;

namespace HosteliteAPI.Models
{
    /// <summary>
    /// The password hash field that holds the hashed value of the user's password
    /// </summary>
    /// <returns></returns>
    public class Photo
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

        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        public User User { get; set; }

        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        public int UserId { get; set; }

        //public Hostel Hostel { get; set; }

        //public int HostelID { get; set; }
  }
}