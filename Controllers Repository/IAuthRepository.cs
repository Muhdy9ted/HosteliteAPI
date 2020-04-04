using HosteliteAPI.Dtos;
using HosteliteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Data
{
    /// <summary>
    /// the interface for the Authrepository 
    /// </summary>
    /// <returns></returns>
    public interface IAuthRepository
    {
        /// <summary>
        /// the register interface for the Authrepository
        /// </summary>
        /// <returns></returns>
        Task<User> Register(User user, string password);

        /// <summary>
        /// the login interface for the Authrepository
        /// </summary>
        /// <returns></returns>
        Task<User> Login(string username);

        /// <summary>
        /// the user exist interface for the Authrepository 
        /// </summary>
        /// <returns></returns>
        Task<bool> UserExists(string username);

    /// <summary>
    /// checks if user password matches with whats in db 
    /// </summary>
    /// <returns></returns>
    Task<bool> VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
