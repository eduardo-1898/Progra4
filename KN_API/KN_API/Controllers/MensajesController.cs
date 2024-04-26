using KN_API.Entities;
using KN_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KN_API.Controllers
{
    public class MensajesController : ApiController
    {

        [HttpGet]
        [Route("mensaje/getMensajes")]
        public List<VerMensaje_Result> getMensajeById(int id)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.VerMensaje(id).ToList();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new List<VerMensaje_Result>();
            }
        }

        [HttpPost]
        [Route("mensaje/insertMensaje")]
        public bool InsertarMensaje(MensajeEnt model)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.InsertarMensaje(model.Mensaje, model.IdTiquete, model.IdUsuario);
                    return (datos > 0);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}