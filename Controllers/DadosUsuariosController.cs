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
    public class DadosUsuariosController : Controller
    {
        private readonly climei_mvcContext _context;

        public DadosUsuariosController(climei_mvcContext context)
        {
            _context = context;
        }

        // GET: DadosUsuarios
        public async Task<IActionResult> Index(string message)
        {
            ViewBag.Message = message;

            var climei_mvcContext = _context.DadosUsuario.Include(d => d.Usuario);
            return View(await climei_mvcContext.ToListAsync());
        }

        // GET: DadosUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DadosUsuario == null)
            {
                return NotFound();
            }

            var dadosUsuario = await _context.DadosUsuario
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosUsuario == null)
            {
                return NotFound();
            }

            return View(dadosUsuario);
        }

        // GET: DadosUsuarios/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email");
            return View();
        }

        // POST: DadosUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Altura,Peso,UsuarioId")] DadosUsuario dadosUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { message = "Registro criado com sucesso" });
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", dadosUsuario.UsuarioId);
            return View(dadosUsuario);
        }

        // GET: DadosUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DadosUsuario == null)
            {
                return NotFound();
            }

            var dadosUsuario = await _context.DadosUsuario.FindAsync(id);
            if (dadosUsuario == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", dadosUsuario.UsuarioId);
            return View(dadosUsuario);
        }

        // POST: DadosUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Altura,Peso,UsuarioId")] DadosUsuario dadosUsuario)
        {
            if (id != dadosUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosUsuarioExists(dadosUsuario.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Email", dadosUsuario.UsuarioId);
            return View(dadosUsuario);
        }

        // GET: DadosUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DadosUsuario == null)
            {
                return NotFound();
            }

            var dadosUsuario = await _context.DadosUsuario
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadosUsuario == null)
            {
                return NotFound();
            }

            return View(dadosUsuario);
        }

        // POST: DadosUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DadosUsuario == null)
            {
                return Problem("Entity set 'climei_mvcContext.DadosUsuario'  is null.");
            }
            var dadosUsuario = await _context.DadosUsuario.FindAsync(id);
            if (dadosUsuario != null)
            {
                _context.DadosUsuario.Remove(dadosUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { message = "Registro removido com sucesso" });
        }

        private bool DadosUsuarioExists(int id)
        {
          return (_context.DadosUsuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
