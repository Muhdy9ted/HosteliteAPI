using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ApplicationDbContext : DbContext
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
                
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public DbSet<Hostel> Hostels { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public DbSet<User> Users { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
