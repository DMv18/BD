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
    public class ModalidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModalidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modalidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modalidades.ToListAsync());
        }

        // GET: Modalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // GET: Modalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modalidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,Activo")] Modalidad modalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modalidad);
        }

        // GET: Modalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidades.FindAsync(id);
            if (modalidad == null)
            {
                return NotFound();
            }
            return View(modalidad);
        }

        // POST: Modalidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,Activo")] Modalidad modalidad)
        {
            if (id != modalidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModalidadExists(modalidad.Id))
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
            return View(modalidad);
        }

        // GET: Modalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modalidad = await _context.Modalidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modalidad == null)
            {
                return NotFound();
            }

            return View(modalidad);
        }

        // POST: Modalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modalidad = await _context.Modalidades.FindAsync(id);
            if (modalidad != null)
            {
                _context.Modalidades.Remove(modalidad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModalidadExists(int id)
        {
            return _context.Modalidades.Any(e => e.Id == id);
        }
    }
}
