using HosteliteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HosteliteAPI.Controllers_Repository
{
  public class HostelRepository : IHostelRepository
  {
    private readonly ApplicationDbContext _context;

    public HostelRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<Hostel> GetHostel(int id)
    {
      var hostel = await _context.Hostels.Include(h => h.Photos).FirstOrDefaultAsync(h => h.ID == id);
      return hostel;
    }

    public async Task<IEnumerable<Hostel>> GetHostels()
    {
      var hostels = await _context.Hostels.Include(h => h.Photos).ToListAsync();
      return hostels;
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}
