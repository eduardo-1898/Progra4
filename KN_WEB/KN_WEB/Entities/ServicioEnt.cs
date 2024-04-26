using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Entities
{
    public class ServicioEnt
    {
        public long idServicio {  get; set; }
        public string TipoServicio { get; set; }
        public int Tiempo { get; set; }
    }
}