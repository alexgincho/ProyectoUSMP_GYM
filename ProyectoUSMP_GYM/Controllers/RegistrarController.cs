using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoUSMP_GYM.Models.Response;
using ProyectoUSMP_GYM.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Controllers
{
    public class RegistrarController : Controller
    {
        private IUsuarioService _Us;
        public RegistrarController(IUsuarioService Us)
        {
            _Us = Us;
        }
        // GET: RegistrarController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistrarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrarController/Create
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

        // GET: RegistrarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrarController/Edit/5
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

        // GET: RegistrarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrarController/Delete/5
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

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] UsuarioRequest users)
        {
            Response rpta = new Response();
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _Us.CreateUsuario(users);
                    if (user != null)
                    {
                        rpta.Data = user;
                        rpta.State = 200;
                        rpta.Message = "Exito!";
                    }
                    else { throw new Exception("Error."); }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                rpta.Message = ex.Message;
                rpta.Data = null;
                rpta.State = 400;
            }
            
            return Ok(rpta);
        }
    }
}
