using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalCrossing.Data;
using AnimalCrossing.Models;
using AnimalCrossing.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalCrossing.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AnimalCrossingContext _context;
        private readonly IAnimalRepository IAnimalRepo;
        private readonly ISpeciesRepository SpeciesRepo;

        public AnimalController(AnimalCrossingContext context, IAnimalRepository iAnimalRepo, ISpeciesRepository Species) {
            _context = context;
            IAnimalRepo = iAnimalRepo;
            SpeciesRepo = Species;
            
        }

        public AnimalController(IAnimalRepository iAnimalRepo) {
            IAnimalRepo = iAnimalRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {


            return View("showCats",IAnimalRepo.Get());
        }

        public string Hello()
        {
            return "Well, hello lthere! we are learning .NET core now...";
        }

        public IActionResult MyFirstView()
        {
            ViewBag.MyWifeSays = "Go buy groceries, clean up, make dinner";
            return View();
        }

        public IActionResult RickRoll()
        {
            ViewBag.RickRollAutoplay = "please report to the administrator if this video doesn't automatical play";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(ViewModelCreator.CreateAnimalCatVm(SpeciesRepo));
        }



        [HttpPost]
        public IActionResult Create(CatDetailsView CatDW)
        {
            if (ModelState.IsValid)
        {

                ViewBag.cat = CatDW.cat;
                ViewBag.Thanks = CatDW.cat.Name;

                IAnimalRepo.Save(CatDW.cat);
                var OppositeCats = IAnimalRepo.OppositeCat(CatDW.cat);

                return View("Thanks", OppositeCats.ToList());


            
    }
            return View(ViewModelCreator.CreateAnimalCatVm(SpeciesRepo));


        }


        [HttpGet]
        public IActionResult EditCat(int Id) {
            // look up cat object from catId in the database
            // Show a edit View to the user, displaying the cat object
            // List<Cat> cats = _context.Cats.ToList();
            //Cat cat = cats.Find(x => x.CatId == catId);

            Cat cat = IAnimalRepo.Get(Id);

            return View("EditCat2", ViewModelCreator.EditAnimalCatVm(SpeciesRepo, cat));
        }

        [HttpPost]
        public IActionResult EditCat(CatDetailsView CatDW) {

            if (ModelState.IsValid) {
                // Save it to the database
                IAnimalRepo.Save(CatDW.cat);


                return RedirectToAction ("index");
            }

            return View(CatDW.cat);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            List<Cat> cats = this.IAnimalRepo.Find(searchString);
            ViewBag.keepSearch = searchString;

            return View("ShowCats", cats.ToList());
        }

        [HttpGet]
        public IActionResult DeleteCat(int id)
        {
            this.IAnimalRepo.Delete(id);


            return View("showCats", this.IAnimalRepo.Get());
        }
        [HttpGet]
        public IActionResult CreateDummyCat()
        {
            this.IAnimalRepo.addDummyCat();
            return View("ShowCats", IAnimalRepo.Get());
        }
    }
}
