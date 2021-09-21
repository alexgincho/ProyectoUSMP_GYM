using Microsoft.AspNetCore.Mvc;
using ProyectoUSMP_GYM.Models.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Controllers
{
    public class PersonalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MantenimientoPersonal(int id = 0)
        {
            return PartialView("_MantenimientoPersonal");
        }

        // Services Rest
        [HttpPost]
        public JsonResult CreatePersonal(Personaladm entity)
        {

            return Json(entity);
        }
    }
}
