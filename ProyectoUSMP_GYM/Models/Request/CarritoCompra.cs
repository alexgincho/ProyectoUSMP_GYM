using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Models.Request
{
    public class CarritoCompra
    {
        public string Codigo { get; set; }
        public double Total { get; set; }
        public List<Detalle> Detalles { get; set; }

    }
    public class Detalle
    {
        public int pkProducto { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
    }
}
