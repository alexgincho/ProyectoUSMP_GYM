using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoUSMP_GYM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProyectoUSMP_GYM.Models.Services.Interfaces;
using ProyectoUSMP_GYM.Models.Response;

namespace ProyectoUSMP_GYM.Controllers
{
    // prueba
    public class HomeController : Controller 
    {

        private IProductoService _sProduct;
        private IUsuarioService _Us;
        private readonly ILogger<HomeController> _loger;


        public HomeController(IProductoService product, IUsuarioService Us, ILogger<HomeController> loger)
        {
            this._sProduct = product;
            this._Us = Us;
            this._loger = loger;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Equipo()
        {
            return View();
        }
     
        public IActionResult Registrar()
        {
            return View();
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
            catch (Exception ex)
            {
                rpta.Message = ex.Message;
                rpta.Data = null;
                rpta.State = 400;
            }

            return Ok(rpta);
        }

        // GET: VistaProducto
        public ActionResult VistaProducto()
        {
            ViewBag.Productos = _sProduct.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult GetProductoxCategoria(int id)
        {

            return Ok();
        }
        public IActionResult WebUser()
        {
            return View();
        }

        public IActionResult probando()
        {
            return View();
        }
    }
}

