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
                rpta.Message = "Success";
                rpta.Data = _sPer.Create(entity);
            }
            catch (Exception ex)
            {
                rpta.Message = ex.Message;
                rpta.Data = null;
            }
            return Ok(rpta);
        }
    }
}
