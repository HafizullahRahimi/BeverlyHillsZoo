using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class HabitatAirsController : Controller
    {
        private readonly HabitatAirService _habitatAirService;

        public HabitatAirsController(HabitatAirService habitatAirService)
        {
            _habitatAirService = habitatAirService;
        }

        // GET: HabitatAirs
        public IActionResult Index()
        {
            var model = _habitatAirService.GetAll();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.HabitatAir'  is null.");
        }

        // GET: HabitatAirs/Details/5
        public IActionResult Details(int id)
        {
            var habitatAir = _habitatAirService.GetById(id);

            if (habitatAir == null)
            {
                return NotFound();
            }

            return View(habitatAir);
        }

        // GET: HabitatAirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HabitatAirs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaxAltitude,Id,Name,IsDeleted")] HabitatAir habitatAir)
        {
            if (ModelState.IsValid)
            {
                _habitatAirService.Insert(habitatAir);
                _habitatAirService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(habitatAir);
        }


        // GET: HabitatAirs/Edit/5
        public IActionResult Edit(int id)
        {
            var habitatAir = _habitatAirService.GetById(id);

            if (habitatAir == null)
            {
                return NotFound();
            }

            return View(habitatAir);

        }

        // POST: HabitatAirs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("MaxAltitude,Id,Name,IsDeleted")] HabitatAir habitatAir)
        {
            if (id != habitatAir.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _habitatAirService.Update(habitatAir);
                    _habitatAirService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(habitatAir);
        }


        // GET: HabitatAirs/Delete/5
        public IActionResult Delete(int id)
        {
            var habitatAir = _habitatAirService.GetById(id);

            if (habitatAir == null)
            {
                return NotFound();
            }

            return View(habitatAir);

        }

        // POST: HabitatAirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var list = _habitatAirService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.HabitatAir'  is null.");
            }


            _habitatAirService.Delete(id);
            _habitatAirService.Save();


            return RedirectToAction(nameof(Index));
        }


        // GET: HabitatAirs/Enable/5
        public IActionResult Enable(int id)
        {

            var habitatAir = _habitatAirService.GetById(id);

            if (habitatAir == null)
            {
                return NotFound();
            }

            return View(habitatAir);

        }

        // POST: HabitatAirs/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public IActionResult EnableConfirmed(int id)
        {
            var list = _habitatAirService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.HabitatAir'  is null.");
            }


            _habitatAirService.Enable(id);
            _habitatAirService.Save();


            return RedirectToAction(nameof(Index));
        }

    }
}
