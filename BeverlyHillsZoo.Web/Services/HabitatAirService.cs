using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Services
{
    public class HabitatAirService : IHabitatAirService
    {

        private readonly ApplicationDbContext _context;

        public HabitatAirService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<HabitatAir> GetAll()
        {
            return _context.HabitatAir.ToList();
        }

        public HabitatAir GetById(int id)
        {
            return _context.HabitatAir.FirstOrDefault(a => a.Id == id);
        }

        public bool Insert(HabitatAir habitatAir)
        {
            try
            {
                _context.HabitatAir.Add(habitatAir);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Update(HabitatAir habitatAir)
        {
            try
            {
                _context.Update(habitatAir);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        public bool Delete(int id)
        {
            var habitatAir = GetById(id);
            habitatAir.IsDeleted = true;
            return Update(habitatAir);

        }
        public bool Enable(int id)
        {
            var habitatAir = GetById(id);
            habitatAir.IsDeleted = false;
            return Update(habitatAir);

        }

    }
}
