using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Services
{
    public class VisitorService : IVisitorService
    {

        private readonly ApplicationDbContext _context;

        public VisitorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Visitor> GetAll()
        {
            return _context.Visitors.ToList();
        }

        public Visitor GetById(int id)
        {
            return _context.Visitors.FirstOrDefault(a => a.Id == id);
        }

        public bool Insert(Visitor visitor)
        {
            try
            {
                _context.Visitors.Add(visitor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Visitor visitor)
        {
            try
            {
                _context.Update(visitor);
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
            var visitor = GetById(id);
            visitor.IsDeleted = true;
            return Update(visitor);

        }
        public bool Enable(int id)
        {
            var visitor = GetById(id);
            visitor.IsDeleted = false;
            return Update(visitor);

        }

        public int HaveVisitor(long personNumber)
        {
            var person = _context.Visitors.FirstOrDefault(a => a.PersonNumber == personNumber);
            if (person != null)
            {
                return person.Id;
            }
            return 0;
        }

    }
}
