using ProyectoUSMP_GYM.Models.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Models.Services.Interfaces
{
    public interface IVentaService
    {
        public Ventum CreateVenta(Ventum venta);
    }
}
