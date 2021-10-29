using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProyectoUSMP_GYM.Controllers
{
    [Route("[controller]")]
    public class EquipoController : Controller
    {
        private readonly ILogger<EquipoController> _logger;

        public EquipoController(ILogger<EquipoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}