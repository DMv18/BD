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
    public class CatalogoDesarrolloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoDesarrolloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CatalogoDesarrollo
        public async Task<IActionResult> Index()
        {
            return View(await _context.CatalogoDesarrollos.ToListAsync());
        }

        // GET: CatalogoDesarrollo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoDesarrollo = await _context.CatalogoDesarrollos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoDesarrollo == null)
            {
                return NotFound();
            }

            return View(catalogoDesarrollo);
        }

        // GET: CatalogoDesarrollo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatalogoDesarrollo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Activo")] CatalogoDesarrollo catalogoDesarrollo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogoDesarrollo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catalogoDesarrollo);
        }

        // GET: CatalogoDesarrollo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoDesarrollo = await _context.CatalogoDesarrollos.FindAsync(id);
            if (catalogoDesarrollo == null)
            {
                return NotFound();
            }
            return View(catalogoDesarrollo);
        }

        // POST: CatalogoDesarrollo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Activo")] CatalogoDesarrollo catalogoDesarrollo)
        {
            if (id != catalogoDesarrollo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogoDesarrollo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoDesarrolloExists(catalogoDesarrollo.Id))
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
            return View(catalogoDesarrollo);
        }

        // GET: CatalogoDesarrollo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoDesarrollo = await _context.CatalogoDesarrollos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalogoDesarrollo == null)
            {
                return NotFound();
            }

            return View(catalogoDesarrollo);
        }

        // POST: CatalogoDesarrollo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogoDesarrollo = await _context.CatalogoDesarrollos.FindAsync(id);
            if (catalogoDesarrollo != null)
            {
                _context.CatalogoDesarrollos.Remove(catalogoDesarrollo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoDesarrolloExists(int id)
        {
            return _context.CatalogoDesarrollos.Any(e => e.Id == id);
        }
    }
}
