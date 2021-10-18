using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Controllers
{
    public class LoginPersonal : Controller
    {
        public IActionResult LoginPers()
        {
            return View();
        }
    }
}
