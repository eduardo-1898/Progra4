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
    public class FaqController : ApiController
    {

        [HttpPost]
        [Route("api/insertarFaq")]
        public IHttpActionResult InsertarFaq([FromBody] FaqEnt faq)
        {
            try
            {
                if (faq == null)
                {
                    return BadRequest("Datos de la FAQ no proporcionados");
                }

                if (string.IsNullOrEmpty(faq.Titulo) || string.IsNullOrEmpty(faq.Descripcion) || string.IsNullOrEmpty(faq.Solucion))
                {
                    return BadRequest("Los datos de la FAQ no pueden estar vacíos");
                }

                using (var context = new Services365Entities()) 
                {
                    var nuevaFaq = new Faq
                    {
                        Titulo = faq.Titulo,
                        Descripcion = faq.Descripcion,
                        Solucion = faq.Solucion
                    };

                    context.Faqs.Add(nuevaFaq);
                    context.SaveChanges();

                    return Ok("FAQ insertada correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("api/obtenerFaq")]
        public IHttpActionResult ObtenerFaq()
        {
            try
            {
                using (var context = new Services365Entities())
                {
                    var preguntasFrecuentes = context.Faqs.ToList();

                    if (preguntasFrecuentes.Count == 0)
                    {
                        return NotFound(); 
                    }

                    var faqs = preguntasFrecuentes.Select(faq => new FaqEnt
                    {
                        IdFaq = faq.IdFaq,
                        Titulo = faq.Titulo,
                        Descripcion = faq.Descripcion,
                        Solucion = faq.Solucion
                    }).ToList();

                    return Ok(faqs); 
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("api/eliminarFaq/{id}")]
        public IHttpActionResult EliminarFaq(int id)
        {
            try
            {
                using (var context = new Services365Entities()) 
                {
                    var faq = context.Faqs.Find(id);

                    if (faq == null)
                    {
                        return NotFound();
                    }

                    context.Faqs.Remove(faq);
                    context.SaveChanges();

                    return Ok("Pregunta frecuente eliminada correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected IHttpActionResult NotFound()
        {
            return Content(System.Net.HttpStatusCode.NotFound, new { Message = "El FAQ no fue encontrado" });
        }

        [HttpPut]
        [Route("api/actualizarFaq/{id}")]
        public IHttpActionResult ActualizarFaq(int id, [FromBody] FaqEnt faqActualizado)
        {
            try
            {
                using (var context = new Services365Entities()) 
                {
                    var faq = context.Faqs.Find(id);

                    if (faq == null)
                    {
                        return NotFound();
                    }

                    faq.Titulo = faqActualizado.Titulo;
                    faq.Descripcion = faqActualizado.Descripcion;
                    faq.Solucion = faqActualizado.Solucion;

                    context.SaveChanges();

                    return Ok("Pregunta frecuente actualizada correctamente");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
