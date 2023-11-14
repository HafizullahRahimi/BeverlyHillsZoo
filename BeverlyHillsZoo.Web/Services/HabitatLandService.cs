using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Data.Services
{
    public class HabitatLandService
    {
        private readonly ApplicationDbContext _context;
        public HabitatLandService(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<List<Models.HabitatLand>> GetAllHabitatLands()
        {
            var habitatLand = await _context.HabitatLand.ToListAsync();
            return habitatLand;
        }
        public async Task AddHabitatLand(HabitatLand habitatLand)
        {

            _context.HabitatLand.Add(habitatLand);
            await _context.SaveChangesAsync();

        }
        public async Task<Models.HabitatLand> GetHabitatLandById(int id)
        {

            var habitatLand = await _context.HabitatLand.FindAsync(id);
            return habitatLand;
        }
        public async Task UpdateHabitatLand(Models.HabitatLand habitatLand)
        {
            _context.Entry(habitatLand).State = EntityState.Modified;
            await _context.SaveChangesAsync();


        }
        public bool HabitatGroundExists(int id)
        {
            var habitatLand = _context.HabitatLand.Any(h => h.Id == id);
            return habitatLand;

        }

        public async Task DeleteHabitatLand(HabitatLand habitatLand)
        {

            _context.HabitatLand.Remove(habitatLand);
            await _context.SaveChangesAsync();

        }
        public bool HabitatLandExists(int id)
        {

            var habitatLand = _context.HabitatLand.Any(h => h.Id == id);
            return habitatLand;

        }
        public async Task IsDeleteUpdate(Models.HabitatLand habitatLand)
        {
            habitatLand.IsDeleted = true;
            _context.Entry(habitatLand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task EnableHabitatLand(Models.HabitatLand habitatLand)
        {

            habitatLand.IsDeleted = false;
            _context.Entry(habitatLand).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

    }
}
