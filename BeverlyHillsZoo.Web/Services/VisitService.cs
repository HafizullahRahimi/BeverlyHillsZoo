using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Services
{
    public class VisitService : IVisitService
    {

        private readonly ApplicationDbContext _context;

        public VisitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Visit> GetAll()
        {
            return _context.Visits.Include(v => v.Animal).Include(v => v.Guide).Include(v => v.Visitor).ToList();
        }

        public Visit GetById(int id)
        {
            return _context.Visits.Include(v => v.Animal).Include(v => v.Guide).Include(v => v.Visitor).FirstOrDefault(a => a.Id == id);
        }

        public bool Insert(Visit visit)
        {
            try
            {
                _context.Visits.Add(visit);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Visit visit)
        {
            try
            {
                _context.Update(visit);
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

            try
            {
                var visit = GetById(id);
                _context.Visits.Remove(visit);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        public int GetNumberOfVisitAtMorning(DateTime date, int animalId)
        {
            var list = _context.Visits.Where(v=> v.VisitDate == date && v.AtMorning && v.AnimalId == animalId).ToList();
            int result = list.Count();
            return result;
        }

        public int GetNumberOfVisitAtAfternoon(DateTime date,int animalId)
        {
            var list = _context.Visits.Where(v => v.VisitDate == date && v.AtAfternoon == true && v.AnimalId == animalId).ToList();
            int result = list.Count;
            return result;
        }

        public int GetNumberOfVisitorVisits(DateTime date, int visitorId, int animalId)
        {
            int numOfVisitsAtMorning = _context.Visits.Where(v => v.VisitDate == date && v.AtMorning == true && v.VisitorId == visitorId && v.AnimalId == animalId).ToList().Count;
            int numOfVisitsAtAfternoon = _context.Visits.Where(v => v.VisitDate == date && v.AtAfternoon == true && v.VisitorId == visitorId && v.AnimalId == animalId).ToList().Count;
            int result = numOfVisitsAtMorning + numOfVisitsAtAfternoon;
            return result;
        }
    }
}
