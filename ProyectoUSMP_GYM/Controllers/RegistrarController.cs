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

        public IActionResult Index()
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
