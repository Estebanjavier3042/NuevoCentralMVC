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
    public class EmpleadoController : Controller
    {
        private readonly NuevoCentralArgentinoContext _context;

        public EmpleadoController(NuevoCentralArgentinoContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            var nuevoCentralArgentinoContext = _context.Empleados.Include(e => e.BaseOperativa).Include(e => e.Categoria).Include(e => e.Servicio);
            return View(await nuevoCentralArgentinoContext.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.BaseOperativa)
                .Include(e => e.Categoria)
                .Include(e => e.Servicio)
                .FirstOrDefaultAsync(m => m.Legajo == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            ViewData["ListaBase"] = new SelectList(_context.BaseOperativas, "IdBase", "Descripcion");
            ViewData["ListaServicio"] = new SelectList(_context.Servicios, "IdServicio", "Descripcion");
            ViewData["ListaCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripcion");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Legajo,Nombre,Apellido,FechaIngreso")] Empleado empleado, int IdServicio, int IdBase, int IdCategoria)
        {

            empleado.BaseOperativaId = IdBase;
            empleado.ServicioId = IdServicio;
            empleado.CategoriaId = IdCategoria;

            if (empleado != null)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BaseOperativaId"] = new SelectList(_context.BaseOperativas, "IdBase", "IdBase", empleado.BaseOperativaId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", empleado.ServicioId);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["ListaBase"] = new SelectList(_context.BaseOperativas, "IdBase", "Descripcion",empleado.BaseOperativaId);
            ViewData["ListaServicio"] = new SelectList(_context.Servicios, "IdServicio", "Descripcion", empleado.ServicioId);
            ViewData["ListaCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripcion", empleado.CategoriaId);
            
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Legajo,Nombre,Apellido,FechaIngreso,BaseOperativaId,ServicioId,CategoriaId")] Empleado empleado)
        {
            if (id != empleado.Legajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Legajo))
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
            ViewData["ListaBase"] = new SelectList(_context.BaseOperativas, "IdBase", "Descripcion", empleado.BaseOperativaId);
            ViewData["ListaServicio"] = new SelectList(_context.Servicios, "IdServicio", "Descripcion", empleado.ServicioId);
            ViewData["ListaCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripcion", empleado.CategoriaId);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.BaseOperativa)
                .Include(e => e.Categoria)
                .Include(e => e.Servicio)
                .FirstOrDefaultAsync(m => m.Legajo == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Legajo == id);
        }
    }
}
