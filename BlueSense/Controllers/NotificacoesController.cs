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
    public class NotificacoesController : Controller
    {
        private readonly FIAPDbContext _context;

        public NotificacoesController(FIAPDbContext context)
        {
            _context = context;
        }

        // GET: Notificacoes
        public async Task<IActionResult> Index()
        {
            var fIAPDbContext = _context.Notificacao.Include(n => n.LeituraSensor).Include(n => n.UsuarioAutoridade);
            return View(await fIAPDbContext.ToListAsync());
        }

        // GET: Notificacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacao
                .Include(n => n.LeituraSensor)
                .Include(n => n.UsuarioAutoridade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // GET: Notificacoes/Create
        public IActionResult Create()
        {
            ViewData["LeituraSensorID"] = new SelectList(_context.LeituraSensor, "ID", "Protocolo");
            ViewData["UsuarioAutoridadeID"] = new SelectList(_context.Set<UsuarioAutoridade>(), "ID", "Nome");
            return View();
        }

        // POST: Notificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Mensagem,DataHora,UsuarioAutoridadeID,LeituraSensorID")] Notificacao notificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeituraSensorID"] = new SelectList(_context.LeituraSensor, "ID", "Protocolo", notificacao.LeituraSensorID);
            ViewData["UsuarioAutoridadeID"] = new SelectList(_context.Set<UsuarioAutoridade>(), "ID", "Nome", notificacao.UsuarioAutoridadeID);
            return View(notificacao);
        }

        // GET: Notificacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacao.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }
            ViewData["LeituraSensorID"] = new SelectList(_context.LeituraSensor, "ID", "Protocolo", notificacao.LeituraSensorID);
            ViewData["UsuarioAutoridadeID"] = new SelectList(_context.Set<UsuarioAutoridade>(), "ID", "Nome", notificacao.UsuarioAutoridadeID);
            return View(notificacao);
        }

        // POST: Notificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Mensagem,DataHora,UsuarioAutoridadeID,LeituraSensorID")] Notificacao notificacao)
        {
            if (id != notificacao.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacaoExists(notificacao.ID))
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
            ViewData["LeituraSensorID"] = new SelectList(_context.LeituraSensor, "ID", "Protocolo", notificacao.LeituraSensorID);
            ViewData["UsuarioAutoridadeID"] = new SelectList(_context.Set<UsuarioAutoridade>(), "ID", "Nome", notificacao.UsuarioAutoridadeID);
            return View(notificacao);
        }

        // GET: Notificacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacao
                .Include(n => n.LeituraSensor)
                .Include(n => n.UsuarioAutoridade)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // POST: Notificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notificacao = await _context.Notificacao.FindAsync(id);
            if (notificacao != null)
            {
                _context.Notificacao.Remove(notificacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoExists(int id)
        {
            return _context.Notificacao.Any(e => e.ID == id);
        }
    }
}
