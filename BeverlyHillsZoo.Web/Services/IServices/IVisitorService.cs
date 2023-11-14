using BeverlyHillsZoo.Web.Models;

namespace BeverlyHillsZoo.Web.Services.IServices
{
    public interface IVisitorService
    {
        List<Visitor> GetAll();
        Visitor GetById(int id);

        bool Insert(Visitor habitatAir);

        bool Update(Visitor habitatAir);

        bool Delete(int id);
        bool Enable(int id);
        void Save();

        int HaveVisitor(long personNumber);

    }
}
