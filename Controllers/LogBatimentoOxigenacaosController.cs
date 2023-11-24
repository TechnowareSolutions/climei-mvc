using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClimeiMvc.Data;
using ClimeiMvc.Models;

namespace ClimeiMvc.Controllers
{
    public class LogBatimentoOxigenacaosController : Controller
    {
        private readonly climei_mvcContext _context;

        public LogBatimentoOxigenacaosController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: LogBatimentoOxigenacaos
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            var climei_mvcContext = _context.LogBatimentoOxigenacao.Include(l => l.Usuario);
            return View(await climei_mvcContext.ToListAsync());
        }

        // GET: LogBatimentoOxigenacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LogBatimentoOxigenacao == null)
            {
                return NotFound();
            }

            var logBatimentoOxigenacao = await _context.LogBatimentoOxigenacao
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logBatimentoOxigenacao == null)
            {
                return NotFound();
            }

            return View(logBatimentoOxigenacao);
        }

        // GET: LogBatimentoOxigenacaos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: LogBatimentoOxigenacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,DataAvaliacao,UsuarioId")] LogBatimentoOxigenacao logBatimentoOxigenacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logBatimentoOxigenacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logBatimentoOxigenacao.UsuarioId);
            return View(logBatimentoOxigenacao);
        }

        // GET: LogBatimentoOxigenacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LogBatimentoOxigenacao == null)
            {
                return NotFound();
            }

            var logBatimentoOxigenacao = await _context.LogBatimentoOxigenacao.FindAsync(id);
            if (logBatimentoOxigenacao == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logBatimentoOxigenacao.UsuarioId);
            return View(logBatimentoOxigenacao);
        }

        // POST: LogBatimentoOxigenacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,DataAvaliacao,UsuarioId")] LogBatimentoOxigenacao logBatimentoOxigenacao)
        {
            if (id != logBatimentoOxigenacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logBatimentoOxigenacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogBatimentoOxigenacaoExists(logBatimentoOxigenacao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { message = "Registro atualizado com sucesso" });
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logBatimentoOxigenacao.UsuarioId);
            return View(logBatimentoOxigenacao);
        }

        // GET: LogBatimentoOxigenacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LogBatimentoOxigenacao == null)
            {
                return NotFound();
            }

            var logBatimentoOxigenacao = await _context.LogBatimentoOxigenacao
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logBatimentoOxigenacao == null)
            {
                return NotFound();
            }

            return View(logBatimentoOxigenacao);
        }

        // POST: LogBatimentoOxigenacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LogBatimentoOxigenacao == null)
            {
                return Problem("Entity set 'climei_mvcContext.LogBatimentoOxigenacao'  is null.");
            }
            var logBatimentoOxigenacao = await _context.LogBatimentoOxigenacao.FindAsync(id);
            if (logBatimentoOxigenacao != null)
            {
                _context.LogBatimentoOxigenacao.Remove(logBatimentoOxigenacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool LogBatimentoOxigenacaoExists(int id)
        {
          return (_context.LogBatimentoOxigenacao?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
