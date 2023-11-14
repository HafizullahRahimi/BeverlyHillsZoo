using BeverlyHillsZoo.Web.Models;

namespace BeverlyHillsZoo.Web.Services.IServices
{
    public interface IGuideService
    {
        List<Guide> GetAll();
        Guide GetById(int id);

        bool Insert(Guide habitatAir);

        bool Update(Guide habitatAir);

        bool Delete(int id);
        bool Enable(int id);
        void Save();
    }
}
