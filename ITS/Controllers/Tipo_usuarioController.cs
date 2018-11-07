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
    public class Tipo_usuarioController : Controller
    {
        private readonly ITSContext _context;

        public Tipo_usuarioController(ITSContext context)
        {
            _context = context;
        }

        // GET: Tipo_usuario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_usuario.ToListAsync());
        }

        // GET: Tipo_usuario/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_usuario = await _context.Tipo_usuario
                .FirstOrDefaultAsync(m => m.id_tipo == id);
            if (tipo_usuario == null)
            {
                return NotFound();
            }

            return View(tipo_usuario);
        }

        // GET: Tipo_usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo,nombre_tipo_usuario")] Tipo_usuario tipo_usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_usuario);
        }

        // GET: Tipo_usuario/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_usuario = await _context.Tipo_usuario.FindAsync(id);
            if (tipo_usuario == null)
            {
                return NotFound();
            }
            return View(tipo_usuario);
        }

        // POST: Tipo_usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_tipo,nombre_tipo_usuario")] Tipo_usuario tipo_usuario)
        {
            if (id != tipo_usuario.id_tipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_usuarioExists(tipo_usuario.id_tipo))
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
            return View(tipo_usuario);
        }

        // GET: Tipo_usuario/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipo_usuario = await _context.Tipo_usuario
                .FirstOrDefaultAsync(m => m.id_tipo == id);
            if (tipo_usuario == null)
            {
                return NotFound();
            }

            return View(tipo_usuario);
        }

        // POST: Tipo_usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tipo_usuario = await _context.Tipo_usuario.FindAsync(id);
            _context.Tipo_usuario.Remove(tipo_usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_usuarioExists(long id)
        {
            return _context.Tipo_usuario.Any(e => e.id_tipo == id);
        }
    }
}
