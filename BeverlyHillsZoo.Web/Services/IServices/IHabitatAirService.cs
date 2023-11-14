using BeverlyHillsZoo.Web.Models;

namespace BeverlyHillsZoo.Web.Services.IServices
{
    public interface IHabitatAirService
    {
        bool Insert(HabitatAir habitatAir);
        bool Update(HabitatAir habitatAir);
        List<HabitatAir> GetAll();
        HabitatAir GetById(int id);
        bool Delete(int id);
        bool Enable(int id);
        void Save();
    }
}
