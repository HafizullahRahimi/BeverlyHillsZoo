using BeverlyHillsZoo.Web.Data.Services;
using BeverlyHillsZoo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class HabitatWaterController : Controller
    {
        private readonly HabitatWaterService _habitatWaterService;

        public HabitatWaterController(HabitatWaterService habitatWaterService)
        {
            _habitatWaterService = habitatWaterService;
        }

        public async Task<IActionResult> Index()
        {
            var habitatWater = await _habitatWaterService.GetAllHabitatWaters();
            return View(habitatWater);
        }

        public async Task<IActionResult> Details(int id)
        {
            var habitatWater = await _habitatWaterService.GetHabitatWaterById(id);
            if (habitatWater == null)
            {
                return NotFound();
            }
            return View(habitatWater);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivingDepth,Id,Name,IsDeleted")] HabitatWater habitatWater)
        {
            if (ModelState.IsValid)
            {
                await _habitatWaterService.AddHabitatWater(habitatWater);
                return RedirectToAction(nameof(Index));
            }
            return View(habitatWater);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var habitatWater = await _habitatWaterService.GetHabitatWaterById(id);
            if (habitatWater == null)
            {
                return NotFound();
            }
            return View(habitatWater);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DivingDepth,Id,Name,IsDeleted")] HabitatWater habitatWater)
        {
            if (id != habitatWater.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _habitatWaterService.UpdateHabitatWater(habitatWater);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitatWaterExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(habitatWater);
        }

        private bool HabitatWaterExists(int id)
        {
            var habitatWater = _habitatWaterService.HabitatWaterExists(id);
            return habitatWater;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var habitatWater = await _habitatWaterService.GetHabitatWaterById(id);
            if (habitatWater == null)
            {
                return NotFound();
            }
            return View(habitatWater);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitatWater = await _habitatWaterService.GetHabitatWaterById(id);
            if (habitatWater == null)
            {
                return NotFound();
            }

            await _habitatWaterService.IsDeleteUpdate(habitatWater);
            return RedirectToAction(nameof(Index));


        }

        // GET: HabitatWaterController/Enable/5
        public async Task<IActionResult> Enable(int id)
        {
            var habitatWater = await _habitatWaterService.GetHabitatWaterById(id);
            if (habitatWater == null)
            {
                return NotFound();
            }
            return View(habitatWater);
        }

        // POST: HabitatWaterController/Enable/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableConfirmed(int id)
        {
            var habitatWater = await _habitatWaterService.GetHabitatWaterById(id);
            if (habitatWater == null)
            {
                return NotFound();
            }

            await _habitatWaterService.EnableHabitatWater(habitatWater);
            return RedirectToAction(nameof(Index));
        }
    }
}
