using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITS.Models;

namespace ITS.Controllers
{
    public class Datos_personalesController : Controller
    {
        private readonly ITSContext _context;

        public Datos_personalesController(ITSContext context)
        {
            _context = context;
        }

        // GET: Datos_personales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datos_personales.ToListAsync());
        }

        // GET: Datos_personales/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_personales = await _context.Datos_personales
                .FirstOrDefaultAsync(m => m.Id_datos == id);
            if (datos_personales == null)
            {
                return NotFound();
            }

            return View(datos_personales);
        }

        // GET: Datos_personales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datos_personales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_datos,Nombre,A_paterno,A_materno,Edad")] Datos_personales datos_personales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datos_personales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datos_personales);
        }

        // GET: Datos_personales/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_personales = await _context.Datos_personales.FindAsync(id);
            if (datos_personales == null)
            {
                return NotFound();
            }
            return View(datos_personales);
        }

        // POST: Datos_personales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id_datos,Nombre,A_paterno,A_materno,Edad")] Datos_personales datos_personales)
        {
            if (id != datos_personales.Id_datos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datos_personales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Datos_personalesExists(datos_personales.Id_datos))
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
            return View(datos_personales);
        }

        // GET: Datos_personales/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datos_personales = await _context.Datos_personales
                .FirstOrDefaultAsync(m => m.Id_datos == id);
            if (datos_personales == null)
            {
                return NotFound();
            }

            return View(datos_personales);
        }

        // POST: Datos_personales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var datos_personales = await _context.Datos_personales.FindAsync(id);
            _context.Datos_personales.Remove(datos_personales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Datos_personalesExists(long id)
        {
            return _context.Datos_personales.Any(e => e.Id_datos == id);
        }
    }
}
