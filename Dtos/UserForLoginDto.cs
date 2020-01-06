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
    public class UserForLoginDto
    {
        /// <summary>
        /// maps to the email field of the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(25, ErrorMessage = "Email address cannot be longer than 25 characters")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// use in generating the passwordhash field in the user database
        /// </summary>
        /// <returns></returns>
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "You must specify a password of minimum 8 characters")]
        public string Password { get; set; }
    }
}
