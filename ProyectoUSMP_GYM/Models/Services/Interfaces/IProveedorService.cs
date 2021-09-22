using ProyectoUSMP_GYM.Models.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Models.Services.Interfaces
{
    public interface IProveedorService
    {
        public void Create(Proveedor entity); //creacion 
        public Proveedor Update(Proveedor entity); // actualizar 
        public List<Proveedor> GetAll(); //lista
        public bool Delete(int id); // eliminar
    }

}