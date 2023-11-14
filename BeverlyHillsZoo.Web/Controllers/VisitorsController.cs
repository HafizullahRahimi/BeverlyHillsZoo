using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using BeverlyHillsZoo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly VisitorService _visitorService;

        public VisitorsController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        // GET: Visitors
        public IActionResult Index()
        {
            var model = _visitorService.GetAll();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.Visitors'  is null.");
        }





        // GET: Visitors/Details/5
        public IActionResult Details(int id)
        {
            var visitor = _visitorService.GetById(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }


        // GET: Visitors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,PersonNumber,IsDeleted")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                int haveVisitor = _visitorService.HaveVisitor(visitor.PersonNumber);
                if (haveVisitor != 0)
                {
                    TempData["Warning"] = $"We have the person number {visitor.PersonNumber}";

                    return View(visitor);
                }


                _visitorService.Insert(visitor);
                _visitorService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public IActionResult Edit(int id)
        {
            var visitor = _visitorService.GetById(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PersonNumber,IsDeleted")] Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _visitorService.Update(visitor);
                    _visitorService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(visitor);


        }


        // GET: Visitors/Delete/5
        public  IActionResult Delete(int id)
        {
            var visitor =_visitorService.GetById(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var list = _visitorService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.HabitatAir'  is null.");
            }


            _visitorService.Delete(id);
            _visitorService.Save();


            return RedirectToAction(nameof(Index));
        }

        // GET: Visitors/Enable/5
        public IActionResult Enable(int id)
        {

            var visitor =  _visitorService.GetById(id);

            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);

        }

        // POST: Visitors/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public IActionResult EnableConfirmed(int id)
        {
            var list =  _visitorService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.Visitor'  is null.");
            }


             _visitorService.Enable(id);
             _visitorService.Save();


            return RedirectToAction(nameof(Index));
        }
    }
}
