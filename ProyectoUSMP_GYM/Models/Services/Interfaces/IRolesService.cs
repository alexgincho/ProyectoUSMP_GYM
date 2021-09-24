using ProyectoUSMP_GYM.Models.Modeldb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Models.Services.Interfaces
{
    public interface IRolesService
    {
        public List<Role> GetRoles();
    }
}
