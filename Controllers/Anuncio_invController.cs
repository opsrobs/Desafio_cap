using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proway_cap.Models;

namespace Proway_Cap.Controllers
{
    public class Anuncio_invController : Controller
    {
        private readonly DBContext _context;

        public Anuncio_invController(DBContext context)
        {
            _context = context;
        }

        // GET: Anuncio_inv
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anuncios.ToListAsync());
        }

        // GET: Anuncio_inv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio_inv = await _context.Anuncios
                .FirstOrDefaultAsync(m => m.Id_anuncio == id);
            if (anuncio_inv == null)
            {
                return NotFound();
            }

            return View(anuncio_inv);
        }

        // GET: Anuncio_inv/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anuncio_inv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_anuncio,Nome_anuncio,Nome_cliente,Data_inicio,Data_fim,Valor_investido")] Anuncio_inv anuncio_inv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anuncio_inv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anuncio_inv);
        }

        // GET: Anuncio_inv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio_inv = await _context.Anuncios.FindAsync(id);
            if (anuncio_inv == null)
            {
                return NotFound();
            }
            return View(anuncio_inv);
        }

        // POST: Anuncio_inv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_anuncio,Nome_anuncio,Nome_cliente,Data_inicio,Data_fim,Valor_investido")] Anuncio_inv anuncio_inv)
        {
            if (id != anuncio_inv.Id_anuncio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuncio_inv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Anuncio_invExists(anuncio_inv.Id_anuncio))
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
            return View(anuncio_inv);
        }

        // GET: Anuncio_inv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio_inv = await _context.Anuncios
                .FirstOrDefaultAsync(m => m.Id_anuncio == id);
            if (anuncio_inv == null)
            {
                return NotFound();
            }

            return View(anuncio_inv);
        }

        // POST: Anuncio_inv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio_inv = await _context.Anuncios.FindAsync(id);
            _context.Anuncios.Remove(anuncio_inv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Anuncio_invExists(int id)
        {
            return _context.Anuncios.Any(e => e.Id_anuncio == id);
        }
    }
}
