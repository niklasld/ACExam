using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalCrossing.Data;
using AnimalCrossing.Models;

namespace AnimalCrossing.Controllers
{
    public class CatDateController : Controller
    {
        private readonly AnimalCrossingContext _context;

        public CatDateController(AnimalCrossingContext context)
        {
            _context = context;
        }

        // GET: CatDate
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatDate.ToListAsync());
        }

        // GET: CatDate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDate = await _context.CatDate
                .FirstOrDefaultAsync(m => m.CatDateId == id);
            if (catDate == null)
            {
                return NotFound();
            }

            return View(catDate);
        }

        // GET: CatDate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatDate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatDateId,HostId,GuestId,Location,DateTime")] CatDate catDate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catDate);
        }

        // GET: CatDate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDate = await _context.CatDate.FindAsync(id);
            if (catDate == null)
            {
                return NotFound();
            }
            return View(catDate);
        }

        // POST: CatDate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatDateId,HostId,GuestId,Location,DateTime")] CatDate catDate)
        {
            if (id != catDate.CatDateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatDateExists(catDate.CatDateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catDate);
        }

        // GET: CatDate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catDate = await _context.CatDate
                .FirstOrDefaultAsync(m => m.CatDateId == id);
            if (catDate == null)
            {
                return NotFound();
            }

            return View(catDate);
        }

        // POST: CatDate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catDate = await _context.CatDate.FindAsync(id);
            _context.CatDate.Remove(catDate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatDateExists(int id)
        {
            return _context.CatDate.Any(e => e.CatDateId == id);
        }
    }
}
