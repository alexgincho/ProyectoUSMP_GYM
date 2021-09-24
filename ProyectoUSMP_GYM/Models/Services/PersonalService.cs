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
        public Personaladm Create(Personaladm entity)
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
                        result.Fechacrea = DateTime.Now;
                        result.FkPersonalcrea = 1;

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
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            string error = "";
            try
            {
                using (var db = new DbContext())
                {
                    var obj = db.Personaladms.Find(id);
                    if (obj != null)
                    {
                        obj.Isdeleted = true;
                        db.SaveChanges();
                        result = true;
                    }
                    else { throw new Exception("Error. Personal Adm no encontrado."); }
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }
            return result;
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
            List<Personaladm> result = null;
            string error = "";
            try
            {
                using (var db = new DbContext())
                {
                    var lst = db.Personaladms.ToList().OrderByDescending( p => p.PkPersonal ).ToList();
                    if(lst.Count() > 0)
                    {
                        result = lst;
                    }
                    else { throw new Exception("Error. No hay Personal Administrativo registrado"); }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return result;
        }

        public Personaladm Update(Personaladm entity)
        {
            Personaladm result = null;
            string error = "";
            try
            {
                using (var db = new DbContext())
                {
                    var obj = db.Personaladms.Find(entity.PkPersonal);
                    if(obj != null)
                    {
                        obj.Dni = entity.Dni;
                        obj.Nombre = entity.Nombre;
                        obj.Apellidopaterno = entity.Apellidopaterno;
                        obj.Apellidomaterno = entity.Apellidomaterno;
                        obj.Direccion = entity.Direccion;
                        obj.Telefono = entity.Telefono;
                        obj.Email = entity.Email;
                        obj.Usuario = entity.Usuario;
                        obj.Passwords = entity.Passwords;
                        db.SaveChanges();
                        result = entity;
                    }
                    else { throw new Exception("Error. Datos no Actualizados"); }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return result;
        }
    }
}
