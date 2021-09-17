using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoUSMP_GYM.Models.Modeldb
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int PkCategoria { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
