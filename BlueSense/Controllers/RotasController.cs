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
    public class RotasController : Controller
    {
        private readonly FIAPDbContext _context;

        public RotasController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: Rotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rota.ToListAsync());
        }

        // GET: Rotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rota = await _context.Rota
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rota == null)
            {
                return NotFound();
            }

            return View(rota);
        }

        // GET: Rotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Origem,Destino")] Rota rota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rota);
        }

        // GET: Rotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rota = await _context.Rota.FindAsync(id);
            if (rota == null)
            {
                return NotFound();
            }
            return View(rota);
        }

        // POST: Rotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Origem,Destino")] Rota rota)
        {
            if (id != rota.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotaExists(rota.ID))
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
            return View(rota);
        }

        // GET: Rotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rota = await _context.Rota
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rota == null)
            {
                return NotFound();
            }

            return View(rota);
        }

        // POST: Rotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rota = await _context.Rota.FindAsync(id);
            if (rota != null)
            {
                _context.Rota.Remove(rota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotaExists(int id)
        {
            return _context.Rota.Any(e => e.ID == id);
        }
    }
}
