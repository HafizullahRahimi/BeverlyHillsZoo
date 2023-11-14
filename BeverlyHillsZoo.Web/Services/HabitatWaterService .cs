using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BeverlyHillsZoo.Web.Data.Services
{
    public class HabitatWaterService
    {
        private readonly ApplicationDbContext _context;

        public HabitatWaterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HabitatWater>> GetAllHabitatWaters()
        {
            return await _context.HabitatWaters.ToListAsync();
        }

        public async Task<HabitatWater> GetHabitatWaterById(int id)
        {
            return await _context.HabitatWaters.FindAsync(id);
        }

        public async Task AddHabitatWater(HabitatWater habitatWater)
        {
            _context.HabitatWaters.Add(habitatWater);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHabitatWater(HabitatWater habitatWater)
        {
            _context.Entry(habitatWater).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task IsDeleteUpdate(HabitatWater habitatWater)
        {
            habitatWater.IsDeleted = true;
            _context.Entry(habitatWater).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task EnableHabitatWater(HabitatWater habitatWater)
        {
            habitatWater.IsDeleted = false;
            _context.Entry(habitatWater).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool HabitatWaterExists(int id)
        {
            return _context.HabitatWaters.Any(e => e.Id == id);
        }
    }
}
