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
    public class LeituraSensoresController : Controller
    {
        private readonly FIAPDbContext _context;

        public LeituraSensoresController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: LeituraSensores
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.LeituraSensor.Include(l => l.Navio).Include(l => l.Rota);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: LeituraSensores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leituraSensor = await _context.LeituraSensor
                .Include(l => l.Navio)
                .Include(l => l.Rota)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leituraSensor == null)
            {
                return NotFound();
            }

            return View(leituraSensor);
        }

        // GET: LeituraSensores/Create
        public IActionResult Create()
        {
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome");
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome");
            return View();
        }

        // POST: LeituraSensores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Protocolo,DataHora,Local,Valor,NavioID,RotaID")] LeituraSensor leituraSensor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leituraSensor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome", leituraSensor.NavioID);
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome", leituraSensor.RotaID);
            return View(leituraSensor);
        }

        // GET: LeituraSensores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leituraSensor = await _context.LeituraSensor.FindAsync(id);
            if (leituraSensor == null)
            {
                return NotFound();
            }
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome", leituraSensor.NavioID);
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome", leituraSensor.RotaID);
            return View(leituraSensor);
        }

        // POST: LeituraSensores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Protocolo,DataHora,Local,Valor,NavioID,RotaID")] LeituraSensor leituraSensor)
        {
            if (id != leituraSensor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leituraSensor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeituraSensorExists(leituraSensor.ID))
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
            ViewData["NavioID"] = new SelectList(_context.Navio, "ID", "Nome", leituraSensor.NavioID);
            ViewData["RotaID"] = new SelectList(_context.Rota, "ID", "Nome", leituraSensor.RotaID);
            return View(leituraSensor);
        }

        // GET: LeituraSensores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leituraSensor = await _context.LeituraSensor
                .Include(l => l.Navio)
                .Include(l => l.Rota)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leituraSensor == null)
            {
                return NotFound();
            }

            return View(leituraSensor);
        }

        // POST: LeituraSensores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leituraSensor = await _context.LeituraSensor.FindAsync(id);
            if (leituraSensor != null)
            {
                _context.LeituraSensor.Remove(leituraSensor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeituraSensorExists(int id)
        {
            return _context.LeituraSensor.Any(e => e.ID == id);
        }
    }
}
