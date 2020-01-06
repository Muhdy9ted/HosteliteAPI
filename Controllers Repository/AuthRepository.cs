using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HosteliteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HosteliteAPI.Data
{
    /// <summary>
    /// the Authrepository that acts a layer of abstraction between our controller and entity framework. 
    /// </summary>
    /// <returns></returns>
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// injecting the entity framework database context
        /// </summary>
        /// <returns></returns>
        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// the Authrepository register method
        /// </summary>
        /// <returns></returns>
        public async Task<User> Register(User user, string password)
        {
            #pragma warning disable IDE0018 // Inline variable declaration
            byte[] passwordHash, passwordSalt;
            #pragma warning restore IDE0018 // Inline variable declaration
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// the Authrepository login method 
        /// </summary>
        /// <returns></returns>
        public async Task<User> Login(string email, string password)
        {
        
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // Auth succesfull
            return user;
            
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// the Authrepository user exists method
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }
    }
}
