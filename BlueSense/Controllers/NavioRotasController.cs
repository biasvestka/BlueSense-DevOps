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
    public class NavioRotasController : Controller
    {
        private readonly FIAPDbContext _context;

        public NavioRotasController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: NavioRotas
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.NavioRotas.Include(n => n.Navio).Include(n => n.Rota);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: NavioRotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navioRotas = await _context.NavioRotas
                .Include(n => n.Navio)
                .Include(n => n.Rota)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (navioRotas == null)
            {
                return NotFound();
            }

            return View(navioRotas);
        }

        // GET: NavioRotas/Create
        public IActionResult Create()
        {
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome");
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome");
            return View();
        }

        // POST: NavioRotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NavioID,RotaID")] NavioRotas navioRotas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(navioRotas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome", navioRotas.NavioID);
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome", navioRotas.RotaID);
            return View(navioRotas);
        }

        // GET: NavioRotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navioRotas = await _context.NavioRotas.FindAsync(id);
            if (navioRotas == null)
            {
                return NotFound();
            }
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome", navioRotas.NavioID);
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome", navioRotas.RotaID);
            return View(navioRotas);
        }

        // POST: NavioRotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NavioID,RotaID")] NavioRotas navioRotas)
        {
            if (id != navioRotas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navioRotas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavioRotasExists(navioRotas.ID))
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
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome", navioRotas.NavioID);
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome", navioRotas.RotaID);
            return View(navioRotas);
        }

        // GET: NavioRotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var navioRotas = await _context.NavioRotas
                .Include(n => n.Navio)
                .Include(n => n.Rota)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (navioRotas == null)
            {
                return NotFound();
            }

            return View(navioRotas);
        }

        // POST: NavioRotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var navioRotas = await _context.NavioRotas.FindAsync(id);
            if (navioRotas != null)
            {
                _context.NavioRotas.Remove(navioRotas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavioRotasExists(int id)
        {
            return _context.NavioRotas.Any(e => e.ID == id);
        }
    }
}
