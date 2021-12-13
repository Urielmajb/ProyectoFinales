using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ACADEMICO.Data;
using ACADEMICO.Models;

namespace ACADEMICO.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ACADEMICOContext _context;

        public CategoriasController(ACADEMICOContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentfilter,
                                               string searchstring,
                                               int? page)
        {

            ViewData["Ordenar1"] = string.IsNullOrEmpty(sortOrder) ? "nombre_desc" : "";

            ViewData["Ordenar2"] = sortOrder== "descripcion_asc" ? "descripcion_desc" : "descripcion_asc";

            ViewData["Ordenar"] = sortOrder;
            
            if (searchstring !=null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentfilter;
            }
            
            ViewData["Filtro"] = searchstring;

            var categoria = from s in _context.Categoria select s;

            if (!string.IsNullOrEmpty(searchstring))
            {
                categoria = categoria.Where(s => s.Nombre.Contains(searchstring) ||
                                            s.Descripcion.Contains(searchstring));

            }
            switch (sortOrder)
            {
                case "nombre_desc":
                    categoria = categoria.OrderByDescending(s => s.Nombre);
                    break;
                case "descripcion_desc":
                    categoria = categoria.OrderByDescending(s => s.Descripcion);
                    break;
                case "descripcion_asc":
                    categoria = categoria.OrderBy(s => s.Descripcion);
                    break;
                default:
                    categoria = categoria.OrderBy(s => s.Nombre);
                    break;
            }

            int pageSize = 10;
            return View(await Paginacion<Categoria>.CreateAsync(categoria.AsNoTracking(), page ?? 1, pageSize));
            //return View(await _context.Categoria.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaID,Nombre,Descripcion,Estado")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaID,Nombre,Descripcion,Estado")] Categoria categoria)
        {
            if (id != categoria.CategoriaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CategoriaID))
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
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaID == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.CategoriaID == id);
        }
    }
}
