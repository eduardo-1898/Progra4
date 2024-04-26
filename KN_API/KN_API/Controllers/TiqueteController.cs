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
    public class TiqueteController : ApiController

    {


        [HttpGet]
        [Route("tiquete/getList")]
        public List<ListarTiquetes_Result> getList()
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.ListarTiquetes().ToList();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new List<ListarTiquetes_Result>();
            }
        }

        [HttpGet]
        [Route("tiquete/getTicket")]
        public BuscarTiquete_Result getTicketById(int id)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.BuscarTiquete(id).First();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new BuscarTiquete_Result();
            }
        }

        [HttpPost]
        [Route("tiquete/insertTiquete")]
        public bool InsertarTiquete(TiqueteEnt model)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.CrearTiquete(model.Titulo, model.Descripcion, null, model.IdUsuario, null, 1, model.IdServicio, model.IdFaq, null);
                    return (datos > 0);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPut]
        [Route("tiquete/updateTiquete")]
        public bool updateTiquete(TiqueteEnt model)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.EditarTiquete((int)model.IdTiquete, model.IdTecnico, model.IdEstado);
                    return (datos > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}