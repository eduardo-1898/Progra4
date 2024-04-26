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
    public class ServicioController : ApiController
    {
        [HttpGet]
        [Route("servicio/getList")]
        public IHttpActionResult ObtenerServicios()
        {
            try
            {
                using (var context = new Services365Entities()) // Reemplaza 'TuDbContext' con tu contexto de base de datos
                {
                    var servicios = context.Servicios.ToList();
                     
                    if (servicios.Count == 0)
                    {
                        return NotFound();
                    }

                    var serviciosEnt = servicios.Select(servicio => new ServicioEnt
                    {
                        IdServicio = servicio.IdServicio,
                        TipoServicio = servicio.TipoServicio,
                        Tiempo = servicio.Tiempo
                    }).ToList();

                    return Ok(serviciosEnt);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("servicio/getService")]
        public ConsultarServicio_Result getServiceById(string id)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.ConsultarServicio(id).First();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new ConsultarServicio_Result();
            }
        }

        [HttpPost]
        [Route("servicio/insertService")]
        public IHttpActionResult InsertarServicio([FromBody] ServicioEnt servicio)
        {
            try
            {
                if (servicio == null)
                {
                    return BadRequest("Datos del servicio no proporcionados");
                }

                if (string.IsNullOrEmpty(servicio.TipoServicio) || servicio.Tiempo <= 0)
                {
                    return BadRequest("Los datos del servicio no son válidos");
                }

                using (var context = new Services365Entities()) 
                {
                    var nuevoServicio = new Servicio
                    {
                        TipoServicio = servicio.TipoServicio,
                        Tiempo = servicio.Tiempo
                    };

                    context.Servicios.Add(nuevoServicio);
                    context.SaveChanges();

                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("api/eliminarServicio/{id}")]
        public IHttpActionResult EliminarServicio(int id)
        {
            try
            {
                using (var context = new Services365Entities()) // Reemplaza con tu contexto de base de datos
                {
                    var servicio = context.Servicios.Find(id);

                    if (servicio == null)
                    {
                        return NotFound();
                    }

                    context.Servicios.Remove(servicio);
                    context.SaveChanges();

                    return Ok("Servicio eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPut]
        [Route("servicio/updateService")]
        public IHttpActionResult ActualizarServicio([FromBody] ServicioEnt servicioActualizado)
        {
            try
            {
                if (servicioActualizado == null)
                {
                    return BadRequest("Datos de servicio no proporcionados");
                }

                if (string.IsNullOrEmpty(servicioActualizado.TipoServicio) || servicioActualizado.Tiempo <= 0)
                {
                    return BadRequest("Los datos de servicio no son válidos");
                }

                using (var context = new Services365Entities()) // Reemplaza con tu contexto de base de datos
                {
                    var servicio = context.Servicios.Find(servicioActualizado.IdServicio);

                    if (servicio == null)
                    {
                        return NotFound();
                    }

                    servicio.TipoServicio = servicioActualizado.TipoServicio;
                    servicio.Tiempo = servicioActualizado.Tiempo;

                    context.SaveChanges();

                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }





    }
}