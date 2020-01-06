using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Models
{
    /// <summary>
    /// The entity framework database context class
    /// </summary>
    /// <returns></returns>
    public class ApplicationDbContext : DbContext

    {
        /// <summary>
        /// The entity framework database context class constructor
        /// </summary>
        /// <returns></returns>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        /// <summary>
        /// registring our hostel model to the entity framework database context
        /// </summary>
        /// <returns></returns>
        public DbSet<Hostel> Hostels { get; set; }

        /// <summary>
        /// registring our user model to the entity framework database context
        /// </summary>
        /// <returns></returns>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// registring our user model to the entity framework database context
        /// </summary>
        /// <returns></returns>
        public DbSet<Photo> Photos { get; set; }
    }
}
