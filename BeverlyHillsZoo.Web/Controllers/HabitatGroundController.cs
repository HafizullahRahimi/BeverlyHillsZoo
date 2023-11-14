using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Data.Services;
using BeverlyHillsZoo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class HabitatGroundController : Controller
    {

        private readonly HabitatLandService _habitatLandService;
        public HabitatGroundController(HabitatLandService habitatLandService)
        {
            _habitatLandService = habitatLandService;
        }

        // GET: HabitatGroundController
        public async Task<IActionResult> Index()
        {

            var habitatLand = await _habitatLandService.GetAllHabitatLands(); ;
            return View(habitatLand);
        }

        // GET: HabitatGroundController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var habitatLand = await _habitatLandService.GetHabitatLandById(id);
            if (habitatLand == null)
            {
                return NotFound();
            }
            return View(habitatLand);
        }

        // GET: HabitatGroundController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HabitatGroundController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Speed,Id,Name,IsDeleted")] HabitatLand habitatLand)
        {

            if (ModelState.IsValid)
            {

                await _habitatLandService.AddHabitatLand(habitatLand);
                return RedirectToAction(nameof(Index));
            }
            return View(habitatLand);
        }


        // GET: HabitatGroundController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var habitatLand = await _habitatLandService.GetHabitatLandById(id);

            if (habitatLand == null)
            {
                return NotFound();
            }
            return View(habitatLand);
        }

        // POST: HabitatGroundController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Speed,Id,Name,IsDeleted")] HabitatLand habitatLand)
        {
            if (id != habitatLand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _habitatLandService.UpdateHabitatLand(habitatLand);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitatGroundExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(habitatLand);
        }
        private bool HabitatGroundExists(int id)
        {
            var habitatLand = _habitatLandService.HabitatGroundExists(id);
            return habitatLand;
        }

        // GET: HabitatGroundController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var habitatLand = await _habitatLandService.GetHabitatLandById(id);
            if (habitatLand == null)
            {

                return NotFound();

            }
            return View(habitatLand);

        }

        // POST: HabitatGroundController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var habitatLand = await _habitatLandService.GetHabitatLandById(id);
            if (habitatLand == null)
            {
                return NotFound();
            }

            await _habitatLandService.IsDeleteUpdate(habitatLand);
            return RedirectToAction(nameof(Index));

        }

        // GET: HabitatGroundController/Enable/5
        public async Task<IActionResult> Enable(int id)
        {

            var habitatLand = await _habitatLandService.GetHabitatLandById(id);
            if (habitatLand == null)
            {

                return NotFound();

            }
            return View(habitatLand);

        }
        // POST: HabitatGroundController/Enable/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableConfirmed(int id)
        {

            var habitatLand = await _habitatLandService.GetHabitatLandById(id);
            if (habitatLand == null)
            {

                return NotFound();
            }
            await _habitatLandService.EnableHabitatLand(habitatLand);
            return RedirectToAction(nameof(Index));
        }
        private bool HabitatLandExists(int id)
        {
            var habitatLand = _habitatLandService.HabitatLandExists(id);
            return habitatLand;

        }
    }
}
