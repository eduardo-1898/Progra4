using KN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KN_API.Controllers
{
    public class EstadoController : ApiController
    {
        [HttpGet]
        [Route("estado/getList")]
        public List<ConsultarTodoEstado_Result> getList()
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.ConsultarTodoEstado().ToList();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new List<ConsultarTodoEstado_Result>();
            }
        }
    }
}