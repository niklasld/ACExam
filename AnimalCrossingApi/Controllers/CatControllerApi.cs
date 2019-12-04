using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalCrossing.Models;
using AutoMapper;
using AnimalCrossing.Models.ViewModels;
using AnimalCrossingApi.Models;

namespace AnimalCrossingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatControllerApi : ControllerBase
    {
        private readonly AnimalCrossingContxtApi2 _context;
        private readonly IMapper _mapper;


        public CatControllerApi(AnimalCrossingContxtApi2 context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/CatControllerApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatVm>>> GetCat()
        {

            // Temporary solution
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<CatProfileAutoMapping>();
                cfg.CreateMap<AnimalCrossing.Models.Cat, CatVm>();
                cfg.CreateMap<List<AnimalCrossing.Models.Cat>, List<CatVm>>();
            });

            var mapper = config.CreateMapper();

            var cats = await _context.Cat.ToListAsync();
            var catVmList = new List<CatVm>();

            foreach (Cat c in cats)
            {
                var catvm = _mapper.Map<CatVm>(c);
                catVmList.Add(catvm);
            }

            return catVmList;
        }


        // GET: api/CatControllerApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            var cat = await _context.Cat.FindAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return cat;
        }

        // PUT: api/CatControllerApi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, Cat cat)
        {
            if (id != cat.CatId)
            {
                return BadRequest();
            }

            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CatControllerApi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(Cat cat)
        {
            _context.Cat.Add(cat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCat", new { id = cat.CatId }, cat);
        }

        // DELETE: api/CatControllerApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cat>> DeleteCat(int id)
        {
            var cat = await _context.Cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cat.Remove(cat);
            await _context.SaveChangesAsync();

            return cat;
        }

        private bool CatExists(int id)
        {
            return _context.Cat.Any(e => e.CatId == id);
        }
    }
}
