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
    public class DocentesController : Controller
    {
        private readonly ACADEMICOContext _context;

        public DocentesController(ACADEMICOContext context)
        {
            _context = context;
        }

        // GET: Docentes
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentfilter,
                                               string searchstring,
                                               int? page)
        {

            ViewData["Ordenar1"] = string.IsNullOrEmpty(sortOrder) ? "nombredocente_desc" : "";

            ViewData["Ordenar"] = sortOrder;

            if (searchstring != null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentfilter;
            }

            ViewData["Filtro"] = searchstring;

            var docentes = from s in _context.Docente select s;

            if (!string.IsNullOrEmpty(searchstring))
            {
                docentes = docentes.Where(s => s.NombreDocente.Contains(searchstring));

            }
            switch (sortOrder)
            {
                case "nombredocente_desc":
                    docentes = docentes.OrderByDescending(s => s.NombreDocente);
                    break;
                default:
                    docentes = docentes.OrderBy(s => s.NombreDocente);
                    break;
            }

            int pageSize = 5;
            return View(await Paginacion<Docente>.CreateAsync(docentes.AsNoTracking(), page ?? 1, pageSize));
            //return View(await _context.Categoria.ToListAsync());
        }


        // GET: Docentes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Docente.ToListAsync());
        //}

        // GET: Docentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docente
                .FirstOrDefaultAsync(m => m.DocenteID == id);
            if (docente == null)
            {
                return NotFound();
            }

            return View(docente);
        }

        // GET: Docentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocenteID,NombreDocente,FechaNacimiento,Edad,Estado")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docente);
        }

        // GET: Docentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docente.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocenteID,NombreDocente,FechaNacimiento,Edad,Estado")] Docente docente)
        {
            if (id != docente.DocenteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocenteExists(docente.DocenteID))
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
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docente = await _context.Docente
                .FirstOrDefaultAsync(m => m.DocenteID == id);
            if (docente == null)
            {
                return NotFound();
            }

            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docente = await _context.Docente.FindAsync(id);
            _context.Docente.Remove(docente);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool DocenteExists(int id)
        {
            return _context.Docente.Any(e => e.DocenteID == id);
        }
    }
}
