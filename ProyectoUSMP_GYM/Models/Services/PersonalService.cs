using ProyectoUSMP_GYM.Models.Modeldb;
using ProyectoUSMP_GYM.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoUSMP_GYM.Models.Services
{
    public class PersonalService : IPersonalService
    {
        public void Create(Personaladm entity)
        {
            Personaladm result = null;
            string error = "";
            try
            {
                using (var db = new DbContext())
                {
                    if(entity != null)
                    {
                        result = new Personaladm();
                        result.Dni = entity.Dni;
                        result.Nombre = entity.Nombre;
                        result.Apellidopaterno = entity.Apellidopaterno;
                        result.Apellidomaterno = entity.Apellidomaterno;
                        result.Direccion = entity.Direccion;
                        result.Telefono = entity.Telefono;
                        result.Email = entity.Email;
                        result.Usuario = entity.Usuario;
                        result.Passwords = entity.Passwords;
                        result.Isdeleted = false;

                        db.Add(result);
                        db.SaveChanges();
                    }
                    else { throw new Exception("Error. Datos vacios."); }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }
        public bool Delete(int id)
        {
            Personaladm result = null;
            string error ="";
            try
            {
                using ( var db = new )

 
            }
            catch
            {

            }
        }
        public Personaladm Get(int id)
        {
            Personaladm result = null;
            string error = "";
            try
            {
                using (var db = new DbContext())
                {
                    var obj = db.Personaladms.Where(u=> u.PkPersonal == id && u.Isdeleted != true);
                    var usuario = obj.FirstOrDefault();
                    if (usuario != null)
                    {
                        result = usuario;
                    }
                    else { throw new Exception("Usuaio no Existe."); }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return result;
        }

        public List<Personaladm> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Personaladm entity)
        {
            throw new NotImplementedException();
        }
    }
}
