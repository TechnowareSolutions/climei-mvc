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
    public class LogAguasController : Controller
    {
        private readonly climei_mvcContext _context;

        public LogAguasController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: LogAguas
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            var climei_mvcContext = _context.LogAgua.Include(l => l.Usuario);
            return View(await climei_mvcContext.ToListAsync());
        }

        // GET: LogAguas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LogAgua == null)
            {
                return NotFound();
            }

            var logAgua = await _context.LogAgua
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logAgua == null)
            {
                return NotFound();
            }

            return View(logAgua);
        }

        // GET: LogAguas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: LogAguas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantidade,DataAvaliacao,UsuarioId")] LogAgua logAgua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logAgua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logAgua.UsuarioId);
            return View(logAgua);
        }

        // GET: LogAguas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LogAgua == null)
            {
                return NotFound();
            }

            var logAgua = await _context.LogAgua.FindAsync(id);
            if (logAgua == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logAgua.UsuarioId);
            return View(logAgua);
        }

        // POST: LogAguas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantidade,DataAvaliacao,UsuarioId")] LogAgua logAgua)
        {
            if (id != logAgua.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logAgua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogAguaExists(logAgua.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", logAgua.UsuarioId);
            return View(logAgua);
        }

        // GET: LogAguas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LogAgua == null)
            {
                return NotFound();
            }

            var logAgua = await _context.LogAgua
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (logAgua == null)
            {
                return NotFound();
            }

            return View(logAgua);
        }

        // POST: LogAguas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LogAgua == null)
            {
                return Problem("Entity set 'climei_mvcContext.LogAgua'  is null.");
            }
            var logAgua = await _context.LogAgua.FindAsync(id);
            if (logAgua != null)
            {
                _context.LogAgua.Remove(logAgua);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool LogAguaExists(int id)
        {
          return (_context.LogAgua?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
