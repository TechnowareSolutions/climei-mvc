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
    public class NivelTemperaturasController : Controller
    {
        private readonly climei_mvcContext _context;

        public NivelTemperaturasController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: NivelTemperaturas
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            return _context.NivelTemperatura != null ? 
                          View(await _context.NivelTemperatura.ToListAsync()) :
                          Problem("Entity set 'climei_mvcContext.NivelTemperatura'  is null.");
        }

        // GET: NivelTemperaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelTemperatura == null)
            {
                return NotFound();
            }

            var nivelTemperatura = await _context.NivelTemperatura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelTemperatura == null)
            {
                return NotFound();
            }

            return View(nivelTemperatura);
        }

        // GET: NivelTemperaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelTemperaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Faixa,DateAvaliacao")] NivelTemperatura nivelTemperatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelTemperatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            return View(nivelTemperatura);
        }

        // GET: NivelTemperaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelTemperatura == null)
            {
                return NotFound();
            }

            var nivelTemperatura = await _context.NivelTemperatura.FindAsync(id);
            if (nivelTemperatura == null)
            {
                return NotFound();
            }
            return View(nivelTemperatura);
        }

        // POST: NivelTemperaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Faixa,DateAvaliacao")] NivelTemperatura nivelTemperatura)
        {
            if (id != nivelTemperatura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelTemperatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelTemperaturaExists(nivelTemperatura.Id))
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
            return View(nivelTemperatura);
        }

        // GET: NivelTemperaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelTemperatura == null)
            {
                return NotFound();
            }

            var nivelTemperatura = await _context.NivelTemperatura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelTemperatura == null)
            {
                return NotFound();
            }

            return View(nivelTemperatura);
        }

        // POST: NivelTemperaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelTemperatura == null)
            {
                return Problem("Entity set 'climei_mvcContext.NivelTemperatura'  is null.");
            }
            var nivelTemperatura = await _context.NivelTemperatura.FindAsync(id);
            if (nivelTemperatura != null)
            {
                _context.NivelTemperatura.Remove(nivelTemperatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool NivelTemperaturaExists(int id)
        {
          return (_context.NivelTemperatura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
