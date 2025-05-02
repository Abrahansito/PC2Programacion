using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC2Programacion.Data;
using PC2Programacion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;



namespace PC2Programacion.Controllers
{
    
    public class PetController : Controller
    {
        private readonly ILogger<PetController> _logger;
        private readonly ApplicationDbContext _context;

        public PetController(ILogger<PetController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }


        
        
        public IActionResult Registrar()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return View(pet);
            }

            _context.DbSetPet.Add(pet);
            _context.SaveChanges();

            TempData["mensaje"] = "Mascota registrada correctamente.";
            return RedirectToAction("Registrar");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}