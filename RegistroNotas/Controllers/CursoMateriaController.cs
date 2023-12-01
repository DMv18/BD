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
    [Authorize(Policy = "Docente")]
    public class CursoMateriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoMateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CursoMateria
        public async Task<IActionResult> Index()
        {
            return View(await _context.CursoMaterias.ToListAsync());
        }

        // GET: CursoMateria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateria = await _context.CursoMaterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoMateria == null)
            {
                return NotFound();
            }

            return View(cursoMateria);
        }

        // GET: CursoMateria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoMateria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CursoMateria cursoMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoMateria);
        }

        // GET: CursoMateria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateria = await _context.CursoMaterias.FindAsync(id);
            if (cursoMateria == null)
            {
                return NotFound();
            }
            return View(cursoMateria);
        }

        // POST: CursoMateria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CursoMateria cursoMateria)
        {
            if (id != cursoMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoMateriaExists(cursoMateria.Id))
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
            return View(cursoMateria);
        }

        // GET: CursoMateria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoMateria = await _context.CursoMaterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoMateria == null)
            {
                return NotFound();
            }

            return View(cursoMateria);
        }

        // POST: CursoMateria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cursoMateria = await _context.CursoMaterias.FindAsync(id);
            if (cursoMateria != null)
            {
                _context.CursoMaterias.Remove(cursoMateria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoMateriaExists(int id)
        {
            return _context.CursoMaterias.Any(e => e.Id == id);
        }
    }
}
