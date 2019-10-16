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
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HostelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hostels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hostel>>> GetHostels()
        {
            return await _context.Hostels.ToListAsync();
        }

        // GET: api/Hostels/5
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
        [HttpPost]
        public async Task<ActionResult<Hostel>> PostHostel(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHostel", new { id = hostel.ID }, hostel);
        }

        // DELETE: api/Hostels/5
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
