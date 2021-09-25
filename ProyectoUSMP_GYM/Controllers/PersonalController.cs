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
    public class PersonalController : Controller
    {
        private  IRolesService _sRol;
        private IPersonalService _sPer;
        public PersonalController(IRolesService sRol, IPersonalService sPer)
        {
            this._sRol = sRol;
            this._sPer = sPer;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoPersonal(int id = 0)
        {
            Personaladm entity = null;
            ViewBag.Roles = _sRol.GetRoles();
            if (id != 0) entity = _sPer.Get(id);
            return PartialView("_MantenimientoPersonal",entity ?? new Personaladm());
        }
      
        // Services Rest
        [HttpPost]
        public IActionResult CreatePersonal([FromBody] Personaladm entity)
        {
            Response rpta = new Response();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                rpta.Data = _sPer.Create(entity);
                rpta.Message = "Success.";
                rpta.State = 200;
            }
            catch (Exception ex)
            {
                rpta.Message = ex.Message;
                rpta.Data = null;
            }
            return Ok(rpta);
        }

        [HttpGet]
        public IActionResult GetAllPersonal()
        {
            Response rpta = new Response();
            try
            {        
                rpta.Data = _sPer.GetAll();
                rpta.State = 200;
                rpta.Message = "Success.";
            }
            catch (Exception ex)
            {
                rpta.Data = null;
                rpta.Message = "Error";
                rpta.State = 400;
            }
            return Ok(rpta);
        }
    }
}
