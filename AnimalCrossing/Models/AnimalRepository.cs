using System;
using System.Collections.Generic;
using AnimalCrossing.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnimalCrossing.Models
{
    public class AnimalRepository : IAnimalRepository
    {

        private readonly AnimalCrossingContext _context;
        public AnimalRepository(AnimalCrossingContext _context)
        {
            this._context = _context;
        }

        public void Delete(int catId)
        {
            _context.Cats.Remove(this.Get(catId));
            _context.SaveChanges();
        }

        public List<Cat> Find(string search)
        {
            var cats = from m in _context.Cats
                       select m;

            if (!String.IsNullOrEmpty(search))
            {
                cats = cats.Include(cat => cat.Species).Where(cat => cat.Name.Contains(search) || cat.Description.Contains(search)
                ||  cat.Species.Name.Contains(search));
            }

            return cats.ToList();

        }

        public List<Cat> Get()
        {
            return _context.Cats.Include(cat => cat.Species).ToList();
        }
            
        public Cat Get(int catId)
        {
            return _context.Cats.Find(catId);
        }

        public void Save(Cat c)
        {
            if (c.CatId == 0)
            {
                _context.Cats.Add(c);
            }
            else
            {
                _context.Cats.Update(c);
            }

            _context.SaveChanges();
        }


        public List<Cat> OppositeCat(Cat c)
        {
            var cats = from cat in _context.Cats.Include(cat => cat.Species)
                       select cat;

            cats = cats.Where(cat => cat.Gender != c.Gender || cat.SpeciesId == c.SpeciesId);

            return cats.ToList();

        }

        public void addDummyCat()
        {
            Cat dummyCat = new Cat();
            dummyCat.Name = "KittyMeow";
            dummyCat.Gender = 0;
            dummyCat.ProfilePicture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTALieQ2I-jffpACKAtUfQb8tT5Ymr8E-0vXHn6wxP2Ol4ia9y5&s";
            dummyCat.SpeciesId = 1;
            dummyCat.Description = "This cat i is made for testing usage.";
            _context.Add(dummyCat);
            _context.SaveChanges();

        }
    }
}
