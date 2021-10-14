using Microsoft.AspNetCore.Mvc;
using ProyectoUSMP_GYM.Models.Modeldb;
using ProyectoUSMP_GYM.Models.Response;
using ProyectoUSMP_GYM.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Controllers
{
    public class ProductoController : Controller
    {
       
        private IProductoService _sPro;
        public ProductoController(IProductoService sPro)
        {
            this._sPro= sPro;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        /*
        public IActionResult MantenimientoProducto(int id = 0)
        {
            //revisar
        }
         */

        // Services Rest
        [HttpPost]
        public IActionResult CreateProducto([FromBody] Producto entity)
        {
            Response rpta = new Response();
            try
            {
                if(ModelState.IsValid)
                {
                    if(entity.PkProducto != 0)
                    {

                    }
                    else
                    {   
                        /* Falta en IProductoService Validar
                        var ValidateCodigo = _sPro.ValidarCodigoProducto(entity.Codigo);
                        var ValidateNombre = _sPro.ValidarNombreProducto(entity.Nombre);
                        if(ValidateCodigo || ValidateNombre)
                        {
                            throw new Exception("Error. Los datos ya se encuentran registrados");
                        }
                        */

                        rpta.Data = _sPro.Create(entity);
                        rpta.Message = "Success";
                        rpta.State = 200;
                    }
                }
                else { return BadRequest(); }
            }
            catch (Exception ex) 
            {
                rpta.State = 404;
                rpta.Message = ex.Message;
                rpta.Data = null;
            }
            return Ok(rpta);
        }
        
        [HttpPost]
        public IActionResult DesactiveProducto([FromBody] int id)
        {
            Response rpta = new Response();
            try
            {
                var DeleteProduct = _sPro.Delete(id);
                if (DeleteProduct)
                {
                    rpta.Data = true;
                    rpta.Message = "Producto Desactivado";
                    rpta.State = 200;
                }
                else { throw new Exception("Error. El producto no se pudo desactivar");}

            }
            catch (Exception ex)
            {
                rpta.State = 404;
                rpta.Data = null;
                rpta.Message = ex.Message; 
                
            }
            return Ok(rpta);
        }

        

    }
}