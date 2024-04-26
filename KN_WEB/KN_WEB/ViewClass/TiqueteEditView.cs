using KN_WEB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.ViewClass
{
    public class TiqueteEditView
    {
        public long IdTiquete { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? IdUsuario { get; set; }
        public string Usuario { get; set; }
        public int? IdTecnico { get; set; }
        public int? IdEstado { get; set; }
        public int? IdServicio { get; set; }
        public string TipoServicio { get; set; }
        public int? IdFaq { get; set; }
        public string Faq { get; set; }
        public int? IdInventario { get; set; }
        public string status { get; set; }
        public int? Tiempo { get; set; }
        public List<MensajeEnt> mensajes { get; set; }
        public List<EstadoEnt> estados { get; set; }
        public List<UsuarioEnt> usuarios { get; set; }
    }
}