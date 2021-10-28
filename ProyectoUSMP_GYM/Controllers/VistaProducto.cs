using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Controllers
{
    public class VistaProducto : Controller
    {
        // GET: VistaProducto
        public ActionResult Index()
        {
            return View();
        }

        // GET: VistaProducto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VistaProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistaProducto/Create
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

        // GET: VistaProducto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VistaProducto/Edit/5
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

        // GET: VistaProducto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VistaProducto/Delete/5
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
