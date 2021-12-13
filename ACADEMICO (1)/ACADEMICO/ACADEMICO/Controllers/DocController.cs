using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACADEMICO.Controllers
{
    public class DocController : Controller
    {
        // GET: DocController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
