using BeverlyHillsZoo.Web.Models;

namespace BeverlyHillsZoo.Web.Services.IServices
{
    public interface IVisitService
    {
        List<Visit> GetAll();
        Visit GetById(int id);

        bool Insert(Visit visit);

        bool Update(Visit visit);

        bool Delete(int id);

        void Save();

        int GetNumberOfVisitAtMorning(DateTime date, int animalId);
        int GetNumberOfVisitAtAfternoon(DateTime date, int animalId);
        int GetNumberOfVisitorVisits(DateTime date, int visitorId, int animalId);

    }
}
