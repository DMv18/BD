using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroNotas.Data;
using RegistroNotas.Models.Cursos;

namespace RegistroNotas.Controllers
{
    
    public class CursoMateriaNotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoMateriaNotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CursoMateriaNota
        [Authorize(Policy = "Estudiante")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CursoMateriasNotas.ToListAsync());
        }

        // GET: CursoMateriaNota/Details/5
        [Authorize(Policy = "Estudiante")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateriaNota = await _context.CursoMateriasNotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoMateriaNota == null)
            {
                return NotFound();
            }

            return View(cursoMateriaNota);
        }

        // GET: CursoMateriaNota/Create
        [Authorize(Policy = "Docente")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoMateriaNota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Docente")]
        public async Task<IActionResult> Create([Bind("Id,Nota")] CursoMateriaNota cursoMateriaNota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoMateriaNota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoMateriaNota);
        }

        // GET: CursoMateriaNota/Edit/5
        [Authorize(Policy = "Docente")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateriaNota = await _context.CursoMateriasNotas.FindAsync(id);
            if (cursoMateriaNota == null)
            {
                return NotFound();
            }
            return View(cursoMateriaNota);
        }

        // POST: CursoMateriaNota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nota")] CursoMateriaNota cursoMateriaNota)
        {
            if (id != cursoMateriaNota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoMateriaNota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoMateriaNotaExists(cursoMateriaNota.Id))
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
            return View(cursoMateriaNota);
        }

        // GET: CursoMateriaNota/Delete/5
        [Authorize(Policy = "Docente")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateriaNota = await _context.CursoMateriasNotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoMateriaNota == null)
            {
                return NotFound();
            }

            return View(cursoMateriaNota);
        }

        // POST: CursoMateriaNota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Docente")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoMateriaNota = await _context.CursoMateriasNotas.FindAsync(id);
            if (cursoMateriaNota != null)
            {
                _context.CursoMateriasNotas.Remove(cursoMateriaNota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoMateriaNotaExists(int id)
        {
            return _context.CursoMateriasNotas.Any(e => e.Id == id);
        }
    }
}
