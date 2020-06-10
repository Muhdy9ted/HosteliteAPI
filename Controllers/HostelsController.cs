using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HosteliteAPI.Models;
using HosteliteAPI.Controllers_Repository;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using HosteliteAPI.Dtos;

namespace HosteliteAPI.Controllers
{
  /// <summary>
  /// the hostel controller class responsible for controlling our hostel APIs
  /// </summary>
  /// <returns></returns>
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class HostelsController : ControllerBase
  {
    private readonly IHostelRepository _repo;
    private readonly IMapper _mapper;

    /// <summary>
    /// injecting our DbContext
    /// </summary>
    /// <returns></returns>
    public HostelsController(IHostelRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    /// <summary>
    /// This API lists all the hostels we have at the moment
    /// </summary>
    /// <returns></returns>
    // GET: api/Hostels
    [HttpGet]
    public async Task<IActionResult> GetHostels()
    {
      var hostels = await _repo.GetHostels();
      var hostelsToReturn = _mapper.Map<IEnumerable<HostelForListDto>>(hostels);
      return Ok(hostelsToReturn);
    }

    /// <summary>
    /// This API gets a particular hostel from the database
    /// </summary>
    /// <param name="id"> Mandatory </param>
    /// <returns></returns>
    // GET: api/Hostels/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHostel(int id)
    {
      var hostel = await _repo.GetHostel(id);
      var hostelToReturn = _mapper.Map<HostelsForDetailedDto>(hostel);
      return Ok(hostelToReturn);
    }

    /// <summary>
    /// This API lets you edit the details of the specified hostel in the database
    /// </summary>
    /// <param name="id"> Mandatory </param>
    /// <param name="hostel"> The hostel object </param>
    /// <returns></returns>
    // PUT: api/Hostels/5
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutHostel(int id, Hostel hostel)
    //{
    //    if (id != hostel.ID)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(hostel).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!HostelExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    /// <summary>
    /// This API saves a new hostel to the database
    /// </summary>
    /// <returns></returns>
    // POST: api/Hostels
    //[HttpPost]
    //public async Task<ActionResult<Hostel>> PostHostel(Hostel hostel)
    //{
    //    _context.Hostels.Add(hostel);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetHostel", new { id = hostel.ID }, hostel);
    //}

    /// <summary>
    /// This API deletes the specified hostel from the database
    /// </summary>
    /// <param name="id"> Mandatory </param>
    /// <returns></returns>
    // DELETE: api/Hostels/5
    //[HttpDelete("{id}")]
    //public async Task<ActionResult<Hostel>> DeleteHostel(int id)
    //{
    //    var hostel = await _context.Hostels.FindAsync(id);
    //    if (hostel == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Hostels.Remove(hostel);
    //    await _context.SaveChangesAsync();

    //    return hostel;
    //}

    //private bool HostelExists(int id)
    //{
    //    return _context.Hostels.Any(e => e.ID == id);
    //}
  }
}
