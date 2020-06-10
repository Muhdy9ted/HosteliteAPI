using HosteliteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Dtos
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;

        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();

            var userData = System.IO.File.ReadAllText("Dtos/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                // create the password hash
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Email = user.Email.ToLower();
                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void SeedHostels()
        {
          _context.Hostels.RemoveRange(_context.Hostels);
          _context.SaveChanges();
          var hostelData = System.IO.File.ReadAllText("Dtos/HostelSeedData.json");
          var hostels = JsonConvert.DeserializeObject<List<Hostel>>(hostelData);
          var users = _context.Users.ToList();
          var countUsers = users.Count;
          Random rnd = new Random();
          foreach ( var hostel in hostels)
          {
            int userId = rnd.Next(1, countUsers);
            hostel.user = _context.Users.FirstOrDefault(u => u.Id == userId);
            hostel.userId = userId;
            //var anonymousType = new
            //{
            //  url = "https://randomuser.me/api/portraits/men/9.jpg",
            //  HostelID = userId
            //};
            //hostel.Photos = (HostelPhoto)anonymousType;
            _context.Hostels.Add(hostel);
            _context.SaveChanges();
          }
        }
    }
}
