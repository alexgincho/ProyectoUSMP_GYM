using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoUSMP_GYM.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Controllers
{
    public class VistaProducto : Controller
    {
        private IProductoService _sProduct;
        public VistaProducto (IProductoService product)
        {
            _sProduct = product;
        }
        // GET: VistaProducto
        public ActionResult Index()
        {
            ViewBag.Productos = _sProduct.GetAll();
            return View();
        }
        [HttpGet]
        public IActionResult GetProductoxCategoria(int id)
        {
            
            return Ok();
        }

    }
}
