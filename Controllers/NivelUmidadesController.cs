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
    public class NivelUmidadesController : Controller
    {
        private readonly climei_mvcContext _context;

        public NivelUmidadesController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: NivelUmidades
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            return _context.NivelUmidade != null ? 
                          View(await _context.NivelUmidade.ToListAsync()) :
                          Problem("Entity set 'climei_mvcContext.NivelUmidade'  is null.");
        }

        // GET: NivelUmidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NivelUmidade == null)
            {
                return NotFound();
            }

            var nivelUmidade = await _context.NivelUmidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelUmidade == null)
            {
                return NotFound();
            }

            return View(nivelUmidade);
        }

        // GET: NivelUmidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelUmidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Faixa,DateAvaliacao")] NivelUmidade nivelUmidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelUmidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            return View(nivelUmidade);
        }

        // GET: NivelUmidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NivelUmidade == null)
            {
                return NotFound();
            }

            var nivelUmidade = await _context.NivelUmidade.FindAsync(id);
            if (nivelUmidade == null)
            {
                return NotFound();
            }
            return View(nivelUmidade);
        }

        // POST: NivelUmidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Faixa,DateAvaliacao")] NivelUmidade nivelUmidade)
        {
            if (id != nivelUmidade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelUmidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelUmidadeExists(nivelUmidade.Id))
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
            return View(nivelUmidade);
        }

        // GET: NivelUmidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NivelUmidade == null)
            {
                return NotFound();
            }

            var nivelUmidade = await _context.NivelUmidade
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nivelUmidade == null)
            {
                return NotFound();
            }

            return View(nivelUmidade);
        }

        // POST: NivelUmidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NivelUmidade == null)
            {
                return Problem("Entity set 'climei_mvcContext.NivelUmidade'  is null.");
            }
            var nivelUmidade = await _context.NivelUmidade.FindAsync(id);
            if (nivelUmidade != null)
            {
                _context.NivelUmidade.Remove(nivelUmidade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool NivelUmidadeExists(int id)
        {
          return (_context.NivelUmidade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
