using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlueSense.Models;
using BlueSense.Persistence;

namespace BlueSense.Controllers
{
    public class NaviosController : Controller
    {
        private readonly FIAPDbContext _context;

        public NaviosController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: Navios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Navio.ToListAsync());
        }

        // GET: Navios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navio = await _context.Navio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (navio == null)
            {
                return NotFound();
            }

            return View(navio);
        }

        // GET: Navios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Navios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,IMO,Tipo")] Navio navio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(navio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(navio);
        }

        // GET: Navios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navio = await _context.Navio.FindAsync(id);
            if (navio == null)
            {
                return NotFound();
            }
            return View(navio);
        }

        // POST: Navios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,IMO,Tipo")] Navio navio)
        {
            if (id != navio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavioExists(navio.ID))
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
            return View(navio);
        }

        // GET: Navios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navio = await _context.Navio
                .FirstOrDefaultAsync(m => m.ID == id);
            if (navio == null)
            {
                return NotFound();
            }

            return View(navio);
        }

        // POST: Navios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var navio = await _context.Navio.FindAsync(id);
            if (navio != null)
            {
                _context.Navio.Remove(navio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavioExists(int id)
        {
            return _context.Navio.Any(e => e.ID == id);
        }
    }
}
