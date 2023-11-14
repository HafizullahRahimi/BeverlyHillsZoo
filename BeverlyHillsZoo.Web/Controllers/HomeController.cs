using BeverlyHillsZoo.Web.Data.Services;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using BeverlyHillsZoo.Web.Services.IServices;
using BeverlyHillsZoo.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HabitatAirService _habitatAirService;
        private readonly AnimalService _animalService;
        private readonly VisitorService _visitorService;
        private readonly VisitService _visitService;
        private readonly HabitatLandService _habitatLandService;
        private readonly HabitatWaterService _habitatWaterService;
        private readonly GuideService _guideService;

        public HomeController(HabitatAirService habitatAirService, AnimalService animalService, VisitorService visitorService, VisitService visitService, HabitatLandService habitatLandService, HabitatWaterService habitatWaterService, GuideService guideService)
        {
            _habitatAirService = habitatAirService;
            _animalService = animalService;
            _visitorService = visitorService;
            _visitService = visitService;
            _habitatLandService = habitatLandService;
            _habitatWaterService = habitatWaterService;
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            ViewData["AirAnimalsTotal"] = _animalService.GetAll().Where(a => a.Type == 1).Count();
            ViewData["LandAnimalsTotal"] = _animalService.GetAll().Where(a => a.Type == 2).Count();
            ViewData["WaterAnimalsTotal"] = _animalService.GetAll().Where(a => a.Type == 3).Count();


            return View();
        }


        // GET: WaterAnimals
        public async Task<IActionResult> WaterAnimals()
        {
            var model = await _habitatWaterService.GetAllHabitatWaters();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.HabitatWater'  is null.");
        }

        // GET: LandAnimals
        public async Task<IActionResult> LandAnimals()
        {
            var model = await _habitatLandService.GetAllHabitatLands();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.HabitatLand'  is null.");
        }


        // GET: LandAnimals
        public IActionResult AirAnimals()
        {
            var model = _habitatAirService.GetAll();
            return model != null ? View(model) : Problem("Entity set 'ApplicationDbContext.HabitatAir'  is null.");
        }

        // GET: Home/HabitatAirVisit/5
        [HttpGet]
        public IActionResult Visit(int id)
        {
            var animal = _animalService.GetAll().FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = animal.Id;
            ViewData["AnimalName"] = animal.Name;


            return View();
        }

        // POST: Home/Visit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Visit([Bind("Id,VisitDate,AtMorning,AtAfternoon,AnimalId,AnimalName,UserName, PersonNumber")] VisitorAndVisitViewModel visitorAndVisitViewModel)
        {
            var visit = new Visit();
            //var habitatAir = _habitatAirService.GetById(visitorAndVisitViewModel.Id);
            var animal = _animalService.GetAll().FirstOrDefault(a => a.Id == visitorAndVisitViewModel.Id);
            ViewData["AnimalId"] = animal.Id;
            ViewData["AnimalName"] = animal.Name;

            #region Warning visitViewModel.AtMorning and visitViewModel.AtAfternoon are False

            //Warning visitViewModel.AtMorning and visitViewModel.AtAfternoon are False
            if (visitorAndVisitViewModel.AtMorning == false && visitorAndVisitViewModel.AtAfternoon == false)
            {
                TempData["Warning"] = $"When do You want visit? AtMorning Or AtAfternoon";

                var model = visitorAndVisitViewModel;

                return View(visitorAndVisitViewModel);
            }
            #endregion

            if (ModelState.IsValid)
            {
                #region Create visitorId

                int visitorId = _visitorService.HaveVisitor(visitorAndVisitViewModel.PersonNumber);

                if (visitorId == 0)
                {
                    _visitorService.Insert(new Visitor()
                    {
                        PersonNumber = visitorAndVisitViewModel.PersonNumber,
                        Name = visitorAndVisitViewModel.UserName
                    });

                    _visitorService.Save();
                    visitorId = _visitorService.HaveVisitor(visitorAndVisitViewModel.PersonNumber);
                }
                #endregion

                #region Warning : Check to a VISITOR Can have 2 visits Per Day

                var numOfVisitorVisits = _visitService.GetNumberOfVisitorVisits(visitorAndVisitViewModel.VisitDate, visitorId, visitorAndVisitViewModel.AnimalId);

                // Warning Number Of Visitor Visits
                if (numOfVisitorVisits == 2)
                {
                    TempData["Warning"] = $" You have TWO Visits on \"{visitorAndVisitViewModel.VisitDate.ToString("dd/MM/yyyy")}\"";
                    return View(visitorAndVisitViewModel);
                }

                #endregion

                #region Warning : Check to a ANIMAL Can have 5 visits Per Day

                int numOfVisitorAtMorning = _visitService.GetNumberOfVisitAtMorning(visitorAndVisitViewModel.VisitDate, visitorAndVisitViewModel.AnimalId);
                int numOfVisitorAtAfternoon = _visitService.GetNumberOfVisitAtAfternoon(visitorAndVisitViewModel.VisitDate, visitorAndVisitViewModel.AnimalId);

                //Warning Num Of Visitor
                if (numOfVisitorAtMorning == 5 && numOfVisitorAtAfternoon == 5)
                {
                    TempData["Warning"] = $" Date \"{visitorAndVisitViewModel.VisitDate.ToString("dd/MM/yyyy")}\" is full";

                    return View(visitorAndVisitViewModel);
                }

                if (numOfVisitorAtMorning == 5 && visitorAndVisitViewModel.AtMorning == true)
                {
                    TempData["Warning"] = $" Date \"{visitorAndVisitViewModel.VisitDate.ToString("dd/MM/yyyy")}\" at morning is full";

                    return View(visitorAndVisitViewModel);
                }

                if (numOfVisitorAtAfternoon == 5 && visitorAndVisitViewModel.AtAfternoon == true)
                {
                    TempData["Warning"] = $" Date \"{visitorAndVisitViewModel.VisitDate.ToString("dd/MM/yyyy")}\" at afternoon is full";

                    return View(visitorAndVisitViewModel);
                }

                #endregion

                #region Set Prop NumberOfVisitor in Visit

                //Set NumberOfVisitor in Visit
                if (visitorAndVisitViewModel.AtMorning)
                {
                    visit.NumberOfVisitor = numOfVisitorAtMorning + 1;
                }
                if (visitorAndVisitViewModel.AtAfternoon)
                {
                    visit.NumberOfVisitor = numOfVisitorAtAfternoon + 1;
                }
                if (visitorAndVisitViewModel.AtMorning && visitorAndVisitViewModel.AtAfternoon)
                {
                    visit.NumberOfVisitor = int.Parse($"{numOfVisitorAtMorning + 1}{numOfVisitorAtAfternoon + 1}");
                }
                #endregion

                #region Set Visit Props


                visit.VisitDate = visitorAndVisitViewModel.VisitDate;
                visit.AtMorning = visitorAndVisitViewModel.AtMorning;
                visit.AtAfternoon = visitorAndVisitViewModel.AtAfternoon;
                visit.AnimalId = visitorAndVisitViewModel.AnimalId;
                visit.VisitorId = visitorId;
                visit.GuideId = _guideService.GetGuideId(animal.Type); 
                #endregion


                _visitService.Insert(visit);
                _visitService.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(visitorAndVisitViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
