using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroNotas.Data;
using RegistroNotas.Models.Catalogos;

namespace RegistroNotas.Controllers
{
    [Authorize(Policy = "Administrador")]
    public class CatalogoMateriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoMateriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatalogoMateria
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogoMaterias.ToListAsync());
        }

        // GET: CatalogoMateria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoMateria = await _context.CatalogoMaterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoMateria == null)
            {
                return NotFound();
            }

            return View(catalogoMateria);
        }

        // GET: CatalogoMateria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogoMateria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo,Parciales")] CatalogoMateria catalogoMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogoMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogoMateria);
        }

        // GET: CatalogoMateria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoMateria = await _context.CatalogoMaterias.FindAsync(id);
            if (catalogoMateria == null)
            {
                return NotFound();
            }
            return View(catalogoMateria);
        }

        // POST: CatalogoMateria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Activo,Parciales")] CatalogoMateria catalogoMateria)
        {
            if (id != catalogoMateria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogoMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoMateriaExists(catalogoMateria.Id))
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
            return View(catalogoMateria);
        }

        // GET: CatalogoMateria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoMateria = await _context.CatalogoMaterias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoMateria == null)
            {
                return NotFound();
            }

            return View(catalogoMateria);
        }

        // POST: CatalogoMateria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogoMateria = await _context.CatalogoMaterias.FindAsync(id);
            if (catalogoMateria != null)
            {
                _context.CatalogoMaterias.Remove(catalogoMateria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoMateriaExists(int id)
        {
            return _context.CatalogoMaterias.Any(e => e.Id == id);
        }
    }
}
