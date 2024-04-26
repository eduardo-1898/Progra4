using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_API.Entities
{
    public class UsuarioEnt
    {
        public string Alias { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public int IdRol { get; set; }
        public int IdUsuario { get; set; }
        public string NombreRol { get; set; }

    }
}