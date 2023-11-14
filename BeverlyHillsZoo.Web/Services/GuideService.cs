using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Services
{
    public class GuideService : IGuideService
    {

        private readonly ApplicationDbContext _context;

        public GuideService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Guide> GetAll()
        {
            return _context.Guides.ToList();
        }

        public Guide GetById(int id)
        {
            return _context.Guides.FirstOrDefault(a => a.Id == id);
        }

        public bool Insert(Guide guide)
        {
            try
            {
                _context.Guides.Add(guide);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Guide guide)
        {
            try
            {
                _context.Update(guide);
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
            var guide = GetById(id);
            guide.IsDeleted = true;
            return Update(guide);

        }
        public bool Enable(int id)
        {
            var guide = GetById(id);
            guide.IsDeleted = false;
            return Update(guide);

        }

        public int GetGuideId(int type)
        {
           var guide=  _context.Guides.FirstOrDefault(a => a.CompetenceType == type);
           return guide.Id;
        }
    }
}
