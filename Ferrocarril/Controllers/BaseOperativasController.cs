using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ferrocarril.Models;

namespace Ferrocarril.Controllers
{
    public class BaseOperativasController : Controller
    {
        private readonly NuevoCentralArgentinoContext _context;

        public BaseOperativasController(NuevoCentralArgentinoContext context)
        {
            _context = context;
        }

        // GET: BaseOperativas
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseOperativas.ToListAsync());
        }

        // GET: BaseOperativas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseOperativa = await _context.BaseOperativas
                .FirstOrDefaultAsync(m => m.IdBase == id);
            if (baseOperativa == null)
            {
                return NotFound();
            }

            return View(baseOperativa);
        }

        // GET: BaseOperativas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseOperativas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBase,Descripcion,Ubicacion")] BaseOperativa baseOperativa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseOperativa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseOperativa);
        }

        // GET: BaseOperativas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseOperativa = await _context.BaseOperativas.FindAsync(id);
            if (baseOperativa == null)
            {
                return NotFound();
            }
            return View(baseOperativa);
        }

        // POST: BaseOperativas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBase,Descripcion,Ubicacion")] BaseOperativa baseOperativa)
        {
            if (id != baseOperativa.IdBase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseOperativa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseOperativaExists(baseOperativa.IdBase))
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
            return View(baseOperativa);
        }

        // GET: BaseOperativas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseOperativa = await _context.BaseOperativas
                .FirstOrDefaultAsync(m => m.IdBase == id);
            if (baseOperativa == null)
            {
                return NotFound();
            }

            return View(baseOperativa);
        }

        // POST: BaseOperativas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseOperativa = await _context.BaseOperativas.FindAsync(id);
            if (baseOperativa != null)
            {
                _context.BaseOperativas.Remove(baseOperativa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseOperativaExists(int id)
        {
            return _context.BaseOperativas.Any(e => e.IdBase == id);
        }
    }
}
