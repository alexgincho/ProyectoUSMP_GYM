using ProyectoUSMP_GYM.Models.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Models.Services.Interfaces
{
    public interface IPersonalService
    {
        public Personaladm Create(Personaladm entity); // Creacion de un Personal Administrativo.
        public Personaladm Get(int id); // Obtener un Personal por su ID.
    }
}
