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
    public class LogUmidadesController : Controller
    {
        private readonly climei_mvcContext _context;

        public LogUmidadesController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: LogUmidades
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            var climei_mvcContext = _context.LogUmidade.Include(l => l.NivelUmidade).Include(l => l.Usuario);
            return View(await climei_mvcContext.ToListAsync());
        }

        // GET: LogUmidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LogUmidade == null)
            {
                return NotFound();
            }

            var logUmidade = await _context.LogUmidade
                .Include(l => l.NivelUmidade)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logUmidade == null)
            {
                return NotFound();
            }

            return View(logUmidade);
        }

        // GET: LogUmidades/Create
        public IActionResult Create()
        {
            ViewData["NivelUmidadeId"] = new SelectList(_context.NivelUmidade, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: LogUmidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Umidade,DataAvaliacao,UsuarioId,NivelUmidadeId")] LogUmidade logUmidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logUmidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            ViewData["NivelUmidadeId"] = new SelectList(_context.NivelUmidade, "Id", "Id", logUmidade.NivelUmidadeId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logUmidade.UsuarioId);
            return View(logUmidade);
        }

        // GET: LogUmidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LogUmidade == null)
            {
                return NotFound();
            }

            var logUmidade = await _context.LogUmidade.FindAsync(id);
            if (logUmidade == null)
            {
                return NotFound();
            }
            ViewData["NivelUmidadeId"] = new SelectList(_context.NivelUmidade, "Id", "Id", logUmidade.NivelUmidadeId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logUmidade.UsuarioId);
            return View(logUmidade);
        }

        // POST: LogUmidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Umidade,DataAvaliacao,UsuarioId,NivelUmidadeId")] LogUmidade logUmidade)
        {
            if (id != logUmidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logUmidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogUmidadeExists(logUmidade.Id))
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
            ViewData["NivelUmidadeId"] = new SelectList(_context.NivelUmidade, "Id", "Id", logUmidade.NivelUmidadeId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logUmidade.UsuarioId);
            return View(logUmidade);
        }

        // GET: LogUmidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LogUmidade == null)
            {
                return NotFound();
            }

            var logUmidade = await _context.LogUmidade
                .Include(l => l.NivelUmidade)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logUmidade == null)
            {
                return NotFound();
            }

            return View(logUmidade);
        }

        // POST: LogUmidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LogUmidade == null)
            {
                return Problem("Entity set 'climei_mvcContext.LogUmidade'  is null.");
            }
            var logUmidade = await _context.LogUmidade.FindAsync(id);
            if (logUmidade != null)
            {
                _context.LogUmidade.Remove(logUmidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool LogUmidadeExists(int id)
        {
          return (_context.LogUmidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
