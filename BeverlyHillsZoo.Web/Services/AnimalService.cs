using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services.IServices;

namespace BeverlyHillsZoo.Web.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly ApplicationDbContext _context;

        public AnimalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Animal> GetAll()
        {
            return _context.Animals.ToList();
        }
    }
}
