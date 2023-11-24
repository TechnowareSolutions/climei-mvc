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
    public class LogTemperaturasController : Controller
    {
        private readonly climei_mvcContext _context;

        public LogTemperaturasController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: LogTemperaturas
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            var climei_mvcContext = _context.LogTemperatura.Include(l => l.NivelTemperatura).Include(l => l.Usuario);
            return View(await climei_mvcContext.ToListAsync());
        }

        // GET: LogTemperaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LogTemperatura == null)
            {
                return NotFound();
            }

            var logTemperatura = await _context.LogTemperatura
                .Include(l => l.NivelTemperatura)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logTemperatura == null)
            {
                return NotFound();
            }

            return View(logTemperatura);
        }

        // GET: LogTemperaturas/Create
        public IActionResult Create()
        {
            ViewData["NivelTemperaturaId"] = new SelectList(_context.NivelTemperatura, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: LogTemperaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperatura,DataAvaliacao,UsuarioId,NivelTemperaturaId")] LogTemperatura logTemperatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logTemperatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            ViewData["NivelTemperaturaId"] = new SelectList(_context.NivelTemperatura, "Id", "Id", logTemperatura.NivelTemperaturaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logTemperatura.UsuarioId);
            return View(logTemperatura);
        }

        // GET: LogTemperaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LogTemperatura == null)
            {
                return NotFound();
            }

            var logTemperatura = await _context.LogTemperatura.FindAsync(id);
            if (logTemperatura == null)
            {
                return NotFound();
            }
            ViewData["NivelTemperaturaId"] = new SelectList(_context.NivelTemperatura, "Id", "Id", logTemperatura.NivelTemperaturaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logTemperatura.UsuarioId);
            return View(logTemperatura);
        }

        // POST: LogTemperaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperatura,DataAvaliacao,UsuarioId,NivelTemperaturaId")] LogTemperatura logTemperatura)
        {
            if (id != logTemperatura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logTemperatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogTemperaturaExists(logTemperatura.Id))
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
            ViewData["NivelTemperaturaId"] = new SelectList(_context.NivelTemperatura, "Id", "Id", logTemperatura.NivelTemperaturaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logTemperatura.UsuarioId);
            return View(logTemperatura);
        }

        // GET: LogTemperaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LogTemperatura == null)
            {
                return NotFound();
            }

            var logTemperatura = await _context.LogTemperatura
                .Include(l => l.NivelTemperatura)
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logTemperatura == null)
            {
                return NotFound();
            }

            return View(logTemperatura);
        }

        // POST: LogTemperaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LogTemperatura == null)
            {
                return Problem("Entity set 'climei_mvcContext.LogTemperatura'  is null.");
            }
            var logTemperatura = await _context.LogTemperatura.FindAsync(id);
            if (logTemperatura != null)
            {
                _context.LogTemperatura.Remove(logTemperatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool LogTemperaturaExists(int id)
        {
          return (_context.LogTemperatura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
