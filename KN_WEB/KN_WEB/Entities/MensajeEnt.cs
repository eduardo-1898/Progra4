using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Entities
{
    public class MensajeEnt
    {
        public int idMensaje { get; set; }
        public string Mensaje { get; set; }
        public DateTime MensjFecha { get; set; }
        public int IdTiquete { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}