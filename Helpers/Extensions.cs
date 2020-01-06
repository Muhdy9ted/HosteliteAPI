using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Helpers
{
    /// <summary>
    /// use for adding headers to our http response displaying the error in our backend if any in production mode
    /// </summary>
    /// <returns></returns>
    public static class Extensions
    {
        /// <summary>
        /// use for adding headers to our http response displaying the error in our backend if any in production mode
        /// </summary>
        /// <returns></returns>
        public static void AddApplicationError(this HttpResponse response, string message) {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public static int CalculateAge(this DateTime theDateTime)
        {
            var age = DateTime.Today.Year - theDateTime.Year;
            if (theDateTime.AddYears(age) > DateTime.Today)
                age--;

            return age;
        }

    }
}
