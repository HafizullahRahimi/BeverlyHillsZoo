using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using BeverlyHillsZoo.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class GuidesController : Controller
    {
        private readonly GuideService _guideService;

        public GuidesController(GuideService guideService)
        {
           _guideService = guideService;
        }

        // GET: Guides
        public IActionResult Index()
        {
            var model = _guideService.GetAll();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.Guides'  is null.");
        }

        // GET: Guides/Details/5
        public IActionResult Details(int id)
        {
            var guide = _guideService.GetById(id);

            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);
        }

        // GET: Guides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guides/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CompetenceType,IsDeleted")] Guide guide)
        {
            if (ModelState.IsValid)
            {
                _guideService.Insert(guide);
                _guideService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(guide);
        }

        // GET: Guides/Edit/5
        public IActionResult Edit(int id)
        {
            var guide = _guideService.GetById(id);

            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);
        }

        // POST: Guides/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,CompetenceType,IsDeleted")] Guide guide)
        {
            if (id != guide.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _guideService.Update(guide);
                    _guideService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(guide);
        }

        // GET: Guides/Delete/5
        public  IActionResult Delete(int id)
        {
            var guide = _guideService.GetById(id);

            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);
        }

        // POST: Guides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var list = _guideService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.HabitatAir'  is null.");
            }


            _guideService.Delete(id);
            _guideService.Save();


            return RedirectToAction(nameof(Index));
        }

        // GET: Guides/Enable/5
        public IActionResult Enable(int id)
        {

            var guide = _guideService.GetById(id);

            if (guide == null)
            {
                return NotFound();
            }

            return View(guide);

        }

        // POST: Guides/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public IActionResult EnableConfirmed(int id)
        {
            var list = _guideService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.Visitor'  is null.");
            }


            _guideService.Enable(id);
            _guideService.Save();


            return RedirectToAction(nameof(Index));
        }
    }
}
