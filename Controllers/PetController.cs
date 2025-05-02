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


        
    public IActionResult CrearAdopcion()
    {
        
        ViewBag.Mascotas = _context.DbSetPet.Where(p => p.EstadoAdopcion == true).ToList();
        ViewBag.Adoptantes = _context.DbSetAdopter.ToList();

        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CrearAdopcion(Adoption adoption)
    {
        if (ModelState.IsValid)
        {
        
            var pet = _context.DbSetPet.FirstOrDefault(p => p.Id == adoption.PetId);
            if (pet != null)
            {
                pet.EstadoAdopcion = false;
                _context.DbSetPet.Update(pet);
            }

            
            _context.Adoption.Add(adoption);
            _context.SaveChanges();

            TempData["mensaje"] = "Adopción registrada correctamente.";
            return RedirectToAction("ListaAdopciones");
        }
        return View(adoption);
    }


    public IActionResult ListaAdopciones()
    {
        var adopciones = _context.DbSetAdoption
            .Include(a => a.Pet)
            .Include(a => a.Adopter)
            .ToList();

        return View(adopciones);
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

            _context.Pet.Add(pet);
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