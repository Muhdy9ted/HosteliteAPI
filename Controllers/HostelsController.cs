using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HosteliteAPI.Models;

namespace HosteliteAPI.Controllers
{
    /// <summary>
    /// The hostel API for CRUD communication with our database
    /// </summary>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// This API DbContext communication
        /// </summary>
        /// <returns></returns>
        public HostelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hostels
        /// <summary>
        /// This API lists all the hostels we have at the moment
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hostel>>> GetHostels()
        {
            return await _context.Hostels.ToListAsync();
        }

        // GET: api/Hostels/5
        /// <summary>
        /// This API gets a particular hostel from the database
        /// </summary>
        /// <param name="id"> Mandatory </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Hostel>> GetHostel(int id)
        {
            var hostel = await _context.Hostels.FindAsync(id);

            if (hostel == null)
            {
                return NotFound();
            }

            return hostel;
        }

        // PUT: api/Hostels/5
        /// <summary>
        /// This API lets you edit the details of the specified hostel in the database
        /// </summary>
        /// <param name="id"> Mandatory </param>
        /// <param name="hostel"> The hostel object </param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHostel(int id, Hostel hostel)
        {
            if (id != hostel.ID)
            {
                return BadRequest();
            }

            _context.Entry(hostel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hostels
        /// <summary>
        /// This API saves a new hostel to the database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Hostel>> PostHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHostel", new { id = hostel.ID }, hostel);
        }

        // DELETE: api/Hostels/5
        /// <summary>
        /// This API deletes the specified hostel from the database
        /// </summary>
        /// <param name="id"> Mandatory </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hostel>> DeleteHostel(int id)
        {
            var hostel = await _context.Hostels.FindAsync(id);
            if (hostel == null)
            {
                return NotFound();
            }

            _context.Hostels.Remove(hostel);
            await _context.SaveChangesAsync();

            return hostel;
        }

        private bool HostelExists(int id)
        {
            return _context.Hostels.Any(e => e.ID == id);
        }
    }
}
