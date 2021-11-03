using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace ProyectoUSMP_GYM.Models.ModelDB
{
    public partial class Usuariologin
    {
        public int PkUsuariologin { get; set; }
        public string Usuario { get; set; }
        public string Passwords { get; set; }
        public int? FkUsuario { get; set; }
        [JsonIgnore]
        public virtual Usuario FkUsuarioNavigation { get; set; }
    }
}
