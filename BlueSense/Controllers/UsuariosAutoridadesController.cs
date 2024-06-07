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
    public class UsuariosAutoridadesController : Controller
    {
        private readonly FIAPDbContext _context;

        public UsuariosAutoridadesController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: UsuariosAutoridades
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioAutoridade.ToListAsync());
        }

        // GET: UsuariosAutoridades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioAutoridade = await _context.UsuarioAutoridade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuarioAutoridade == null)
            {
                return NotFound();
            }

            return View(usuarioAutoridade);
        }

        // GET: UsuariosAutoridades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuariosAutoridades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Departamento,Descricao,ID,Nome,Email,Senha")] UsuarioAutoridade usuarioAutoridade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioAutoridade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioAutoridade);
        }

        // GET: UsuariosAutoridades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioAutoridade = await _context.UsuarioAutoridade.FindAsync(id);
            if (usuarioAutoridade == null)
            {
                return NotFound();
            }
            return View(usuarioAutoridade);
        }

        // POST: UsuariosAutoridades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Departamento,Descricao,ID,Nome,Email,Senha")] UsuarioAutoridade usuarioAutoridade)
        {
            if (id != usuarioAutoridade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioAutoridade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioAutoridadeExists(usuarioAutoridade.ID))
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
            return View(usuarioAutoridade);
        }

        // GET: UsuariosAutoridades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioAutoridade = await _context.UsuarioAutoridade
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuarioAutoridade == null)
            {
                return NotFound();
            }

            return View(usuarioAutoridade);
        }

        // POST: UsuariosAutoridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioAutoridade = await _context.UsuarioAutoridade.FindAsync(id);
            if (usuarioAutoridade != null)
            {
                _context.UsuarioAutoridade.Remove(usuarioAutoridade);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioAutoridadeExists(int id)
        {
            return _context.UsuarioAutoridade.Any(e => e.ID == id);
        }
    }
}
