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
using ProyectoUSMP_GYM.Models.ModelDB;

namespace ProyectoUSMP_GYM.Controllers
{
    public class HomeController : Controller 
    {

        private IProductoService _sProduct;
        private IUsuarioService _Us;
        private readonly ILogger<HomeController> _loger;

        public List<CarritoData> carritoDatas = new List<CarritoData>();

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
                    //var user = _Us.CreateUsuario(users);
                    //if (user != null)
                    //{
                    //    rpta.Data = user;
                    //    rpta.State = 200;
                    //    rpta.Message = "Exito!";
                    //}
                    //else { throw new Exception("Error."); }
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
        public IActionResult VistaProducto()
        {
            return View();
        }
        public IActionResult GetProductosAll()
        {
            Response rpta = new Response();
            try
            {
                var LstProducto = _sProduct.GetAll();
                if(LstProducto.Count > 0)
                {
                    rpta.Data = LstProducto;
                    rpta.State = 200;
                    rpta.Message = "Success";
                }
                else { throw new Exception();  }
            }
            catch (Exception ex)
            {
                rpta.Data = null;
                rpta.State = 400;
                rpta.Message = "Error";
            }
            return Ok(rpta);
        }
        public IActionResult GetProducto(int id)
        {
            Producto producto = new Producto();
            try
            {             
                var prod = _sProduct.Get(id);
                if(prod != null) { producto = prod; }
                else { prod = null; }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return View(producto);
        }

        //[HttpPost]
        //public IActionResult InsertarCarrito(Producto prod)
        //{
        //    int respuesta = 0;
        //    if(prod != null) { respuesta = 0; }
        //    else
        //    {
        //        CarritoData carrito = new CarritoData();
        //        carrito.FkProducto = prod.PkProducto;
        //        carritoDatas.Add(carrito);
        //        respuesta = 1;
        //    }
        //    return Ok(respuesta);
        //}



        [HttpGet]
        public IActionResult GetProductoxCategoria(int id)
        {

            return Ok();
        }
        public IActionResult WebUser()
        {
            return View();
        }

        public IActionResult Carrito()
        {
            return View();
        }
    }
}

