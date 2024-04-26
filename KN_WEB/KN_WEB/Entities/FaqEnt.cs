using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KN_WEB.Entities
{
    public class FaqEnt
    {
        public int IdFaq { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Solucion { get; set; }
    }
}