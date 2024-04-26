using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Entities
{
    public class TiqueteEnt
    {
        public long IdTiquete { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinal { get;set; }
        public int? IdUsuario { get; set; }
        public int? IdTecnico { get; set; }
        public int? IdEstado { get; set; }
        public int? IdServicio { get; set; }
        public int? IdFaq { get; set; }
        public int? IdInventario { get; set; }
        public string status { get; set; }
        public int? Tiempo { get; set; }

    }
}