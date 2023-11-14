using BeverlyHillsZoo.Web.Data.Context;
using BeverlyHillsZoo.Web.Models;
using BeverlyHillsZoo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeverlyHillsZoo.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AnimalService _animalService;

        public AdminController(ApplicationDbContext context, AnimalService animalService)
        {
            _context = context;
            _animalService = animalService;
        }

        public IActionResult Index()
        {
            var model = _animalService.GetAll();

            return View(model);
        }
    }
}
