using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using BeverlyHillsZoo.Web.ViewModels;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class VisitsController : Controller
    {
        private readonly VisitService _visitService;
        private readonly VisitorService _visitorService;
        private readonly AnimalService _animalService;
        private readonly GuideService _guideService;

        public VisitsController(VisitService visitService, VisitorService visitorService, AnimalService animalService, GuideService guideService)
        {
            _visitService = visitService;
            _animalService = animalService;
            _visitorService = visitorService;
            _guideService = guideService;
        }

        // GET: Visits
        public IActionResult Index()
        {
            var model = _visitService.GetAll();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.Visits'  is null.");
        }

        // GET: Visits/Details/5
        public IActionResult Details(int id)
        {

            var visit = _visitService.GetById(id);

            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }



        // GET: Visits/Create
        public IActionResult Create()
        {
           
            ViewData["AnimalId"] = new SelectList(_animalService.GetAll(), "Id", "Name");
            ViewData["VisitorId"] = new SelectList(_visitorService.GetAll(), "Id", "Name");
            ViewData["GuideId"] = new SelectList(_guideService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Visits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,NumberOfVisitor,VisitDate,IsVisited,AtMorning,AtAfternoon,AnimalId,VisitorId,GuideId")] VisitViewModel visitViewModel)
        {
            var visit = new Visit();
            ViewData["AnimalId"] = new SelectList(_animalService.GetAll(), "Id", "Name");
            ViewData["VisitorId"] = new SelectList(_visitorService.GetAll(), "Id", "Name");
            ViewData["GuideId"] = new SelectList(_guideService.GetAll(), "Id", "Id");

            #region Warning visitViewModel.AtMorning and visitViewModel.AtAfternoon are False

            //Warning visitViewModel.AtMorning and visitViewModel.AtAfternoon are False
            if (visitViewModel.AtMorning == false && visitViewModel.AtAfternoon == false)
            {
                TempData["Warning"] = $"When do You want visit? AtMorning Or AtAfternoon";

                return View(visitViewModel);
            }
            #endregion

            if (ModelState.IsValid)
            {

                #region Warning : Check to a VISITOR Can have 2 visits Per Day

                var numOfVisitorVisits = _visitService.GetNumberOfVisitorVisits(visitViewModel.VisitDate, visitViewModel.VisitorId, visitViewModel.AnimalId);

                // Warning Number Of Visitor Visits
                if (numOfVisitorVisits == 2)
                {
                    TempData["Warning"] = $" You have TWO Visits on \"{visitViewModel.VisitDate.ToString("dd/MM/yyyy")}\"";
                    return View(visitViewModel);
                }

                #endregion

                #region Warning : Check to a ANIMAL Can have 5 visits Per Day

                int numOfVisitorAtMorning = _visitService.GetNumberOfVisitAtMorning(visitViewModel.VisitDate, visitViewModel.AnimalId);
                int numOfVisitorAtAfternoon = _visitService.GetNumberOfVisitAtAfternoon(visitViewModel.VisitDate, visitViewModel.AnimalId);

                //Warning Num Of Visitor
                if (numOfVisitorAtMorning == 5 && numOfVisitorAtAfternoon == 5)
                {
                    TempData["Warning"] = $" Date \"{visitViewModel.VisitDate.ToString("dd/MM/yyyy")}\" is full";

                    return View(visitViewModel);
                }

                if (numOfVisitorAtMorning == 5 && visitViewModel.AtMorning == true)
                {
                    TempData["Warning"] = $" Date \"{visitViewModel.VisitDate.ToString("dd/MM/yyyy")}\" at morning is full";

                    return View(visitViewModel);
                }

                if (numOfVisitorAtAfternoon == 5 && visitViewModel.AtAfternoon == true)
                {
                    TempData["Warning"] = $" Date \"{visitViewModel.VisitDate.ToString("dd/MM/yyyy")}\" at afternoon is full";

                    return View(visitViewModel);
                }

                #endregion

                #region Set Prop NumberOfVisitor in Visit

                //Set NumberOfVisitor in Visit
                if (visitViewModel.AtMorning)
                {
                    visit.NumberOfVisitor = numOfVisitorAtMorning + 1;
                }
                if (visitViewModel.AtAfternoon)
                {
                    visit.NumberOfVisitor = numOfVisitorAtAfternoon + 1;
                }
                if (visitViewModel.AtMorning && visitViewModel.AtAfternoon)
                {
                    visit.NumberOfVisitor = int.Parse($"{numOfVisitorAtMorning + 1}{numOfVisitorAtAfternoon + 1}");
                }
                #endregion

                #region Set Visit Props

                //visit.NumberOfVisitor = visitViewModel.NumberOfVisitor;
                visit.VisitDate = visitViewModel.VisitDate;
                visit.AtMorning = visitViewModel.AtMorning;
                visit.AtAfternoon = visitViewModel.AtAfternoon;
                visit.AnimalId = visitViewModel.AnimalId;
                visit.VisitorId = visitViewModel.VisitorId;
                visit.GuideId = visitViewModel.GuideId;
                #endregion


                _visitService.Insert(visit);
                _visitService.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(visitViewModel);
        }



        // GET: Visits/Edit/5
        public IActionResult Edit(int id)
        {
            var visit = _visitService.GetById(id);

            if (visit == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_animalService.GetAll(), "Id", "Name", visit.AnimalId);
            ViewData["VisitorId"] = new SelectList(_visitorService.GetAll(), "Id", "Name", visit.VisitorId);
            ViewData["GuideId"] = new SelectList(_guideService.GetAll(), "Id", "Name");
            return View(visit);
        }

        // POST: Visits/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,NumberOfVisitor,VisitDate,IsVisited,AtMorning,AtAfternoon,AnimalId,VisitorId,GuideId")] VisitViewModel visitViewModel)
        {
            if (id != visitViewModel.Id)
            {
                return NotFound();
            }

            var visit = new Visit();



            if (ModelState.IsValid)
            {
                try
                {
                    visit.Id = visitViewModel.Id;
                    visit.NumberOfVisitor = visitViewModel.NumberOfVisitor;
                    visit.VisitDate = visitViewModel.VisitDate;
                    visit.AtMorning = visitViewModel.AtMorning;
                    visit.AtAfternoon = visitViewModel.AtAfternoon;
                    visit.AnimalId = visitViewModel.AnimalId;
                    visit.VisitorId = visitViewModel.VisitorId;
                    visit.GuideId = visitViewModel.GuideId;
                    visit.IsVisited = visitViewModel.IsVisited;

                    _visitService.Update(visit);
                    _visitService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_animalService.GetAll(), "Id", "Name", visit.AnimalId);
            ViewData["VisitorId"] = new SelectList(_visitorService.GetAll(), "Id", "Name", visit.VisitorId);
            ViewData["GuideId"] = new SelectList(_guideService.GetAll(), "Id", "Name");
            return View(visit);
        }



        // GET: Visits/Delete/5
        public IActionResult Delete(int id)
        {
            var visit = _visitService.GetById(id);

            if (visit == null)
            {
                return NotFound();
            }

            return View(visit);
        }

        // POST: Visits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var list = _visitService.GetAll();
            if (list.Count < 1)
            {
                return Problem("Entity set 'ApplicationDbContext.Visits'  is null.");
            }


            _visitService.Delete(id);
            _visitService.Save();


            return RedirectToAction(nameof(Index));
        }


    }
}
