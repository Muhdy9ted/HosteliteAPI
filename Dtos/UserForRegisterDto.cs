using HosteliteAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
    /// <summary>
    /// the register dto that interfaces with the user input and the user database
    /// </summary>
    /// <returns></returns>
    public class UserForRegisterDto
    {
        /// <summary>
        /// maps to the email field of the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(35, ErrorMessage = "Email address cannot be longer than 35 characters")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// use in generating the passwordhash field in the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "You must specify a password of minimum 8 characters")]
        public string Password { get; set; }

        /// <summary>
        /// use in generating the passwordhash field in the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(30)]
        public string firstname { get; set; }

        /// <summary>
        /// use in generating the passwordhash field in the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(30)]
        public string lastname { get; set; }

        /// <summary>
        /// use in generating the passwordhash field in the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        public DateTime DOB { get; set; }

        /// <summary>
        /// use in generating the passwordhash field in the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(10)]
        public string gender { get; set; }

        /// <summary>
        /// The password hash field that holds the hashed value of the user's password
        /// </summary>
        /// <returns></returns>
        /// 
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateJoined { get; set; }

        //public Photo profilePhoto { get; set; }


        public UserForRegisterDto()
        {
            DateJoined = DateTime.Now;

            //profilePhoto = new Photo();
        }
    }
}
