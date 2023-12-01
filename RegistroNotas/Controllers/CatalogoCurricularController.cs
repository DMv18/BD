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
    
    public class CatalogoCurricularController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoCurricularController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatalogoCurricular
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogoCurriculares.ToListAsync());
        }

        // GET: CatalogoCurricular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoCurricular = await _context.CatalogoCurriculares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoCurricular == null)
            {
                return NotFound();
            }

            return View(catalogoCurricular);
        }

        // GET: CatalogoCurricular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogoCurricular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo")] CatalogoCurricular catalogoCurricular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogoCurricular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(catalogoCurricular);
        }

        // GET: CatalogoCurricular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoCurricular = await _context.CatalogoCurriculares.FindAsync(id);
            if (catalogoCurricular == null)
            {
                return NotFound();
            }

            return View(catalogoCurricular);
        }

        // POST: CatalogoCurricular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Descripcion,Activo")] CatalogoCurricular catalogoCurricular)
        {
            if (id != catalogoCurricular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogoCurricular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoCurricularExists(catalogoCurricular.Id))
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

            return View(catalogoCurricular);
        }

        // GET: CatalogoCurricular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoCurricular = await _context.CatalogoCurriculares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoCurricular == null)
            {
                return NotFound();
            }

            return View(catalogoCurricular);
        }

        // POST: CatalogoCurricular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogoCurricular = await _context.CatalogoCurriculares.FindAsync(id);
            if (catalogoCurricular != null)
            {
                _context.CatalogoCurriculares.Remove(catalogoCurricular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoCurricularExists(int id)
        {
            return _context.CatalogoCurriculares.Any(e => e.Id == id);
        }
    }
}