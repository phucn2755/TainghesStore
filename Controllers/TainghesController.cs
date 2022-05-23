using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TainghesStore.Data;
using TainghesStore.Models;

namespace TainghesStore.Controllers
{
    public class TainghesController : Controller
    {
        private readonly TainghesStoreContext _context;

        public TainghesController(TainghesStoreContext context)
        {
            _context = context;
        }

        // GET: Tainghes
        public async Task<IActionResult> Index(string taingheGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Tainghe
                                            orderby b.Genre
                                            select b.Genre;
            var tainghes = from b in _context.Tainghe
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                tainghes = tainghes.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(taingheGenre))
            {
                tainghes = tainghes.Where(x => x.Genre == taingheGenre);
            }
            var GenreVM = new GenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                Tainghes = await tainghes.ToListAsync()
            };
            return View(GenreVM);
        }


        // GET: Tainghes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tainghe = await _context.Tainghe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tainghe == null)
            {
                return NotFound();
            }

            return View(tainghe);
        }

        // GET: Tainghes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tainghes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Price,Rating")] Tainghe tainghe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tainghe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tainghe);
        }

        // GET: Tainghes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tainghe = await _context.Tainghe.FindAsync(id);
            if (tainghe == null)
            {
                return NotFound();
            }
            return View(tainghe);
        }

        // POST: Tainghes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Price,Rating")] Tainghe tainghe)
        {
            if (id != tainghe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tainghe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaingheExists(tainghe.Id))
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
            return View(tainghe);
        }

        // GET: Tainghes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tainghe = await _context.Tainghe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tainghe == null)
            {
                return NotFound();
            }

            return View(tainghe);
        }

        // POST: Tainghes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tainghe = await _context.Tainghe.FindAsync(id);
            _context.Tainghe.Remove(tainghe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaingheExists(int id)
        {
            return _context.Tainghe.Any(e => e.Id == id);
        }
    }
}
