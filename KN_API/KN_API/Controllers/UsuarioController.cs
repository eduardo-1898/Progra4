using KN_API.Entities;
using KN_API.Models;
using KN_API.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KN_API.Controllers
{

    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("api/IniciarSesion")]
        public IniciarSesion_Result IniciarSesion(UsuarioEnt entidad)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.IniciarSesion(entidad.Correo, entidad.Contrasenna).FirstOrDefault();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new IniciarSesion_Result();

            }
        }

        [HttpPost]
        [Route("api/RegistrarUsuario")]
        public bool RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    bd.RegistrarUsuario(entidad.Alias,
                                        entidad.Nombre,
                                        entidad.Apellido1,
                                        entidad.Apellido2,
                                        entidad.Correo,
                                        entidad.Contrasenna,
                                        entidad.IdRol);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }

        [HttpPost]
        [Route("api/authenticate")]
        public IHttpActionResult Authenticate(KeyRequest key)
        {
            if (key == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            bool isCredentialValid = (key.Key == ConfigurationManager.AppSettings["JWT_SECRET_KEY"]);
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(key.Key);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("api/login/CambiarContrasenna")]
        public bool CambiarContrasenna(UsuarioEnt entidad)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    bd.CambiarContrasena(entidad.Correo, entidad.Contrasenna);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpGet]
        [Route("api/ConsultarUsuarios")]
        public List<UsuarioEnt> ConsultarUsuarios() 
        {
            using (var bd = new Services365Entities())
            {
                return bd.Database.SqlQuery<UsuarioEnt>("ConsultarUsuarios").ToList();
            }
        }


        [HttpGet]
        [Route("usuario/getUser")]
        public ConsultarUsuarios_Result getServiceById(string id)
        {
            try
            {
                using (var bd = new Services365Entities())
                {
                    var datos = bd.ConsultarUsuarios().Where(x=>x.IdUsuario == Convert.ToInt32(id)).FirstOrDefault();
                    return datos;
                }
            }
            catch (Exception)
            {
                return new ConsultarUsuarios_Result();
            }
        }

        [HttpPut]
        [Route("usuario/updateUser")]
        public IHttpActionResult ActualizarServicio([FromBody] UsuarioEnt usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest("Datos de usuario no proporcionados");
                }

                using (var context = new Services365Entities()) // Reemplaza con tu contexto de base de datos
                {
                    var usuarioModel = context.Usuarios.Find(usuario.IdUsuario);

                    if (usuarioModel == null)
                    {
                        return NotFound();
                    }

                    usuarioModel.IdRol = usuario.IdRol;
                    usuarioModel.Nombre = usuario.Nombre;
                    usuarioModel.Apellido1 = usuario.Apellido1;
                    usuarioModel.Apellido2 = usuario.Apellido2;
                    usuarioModel.Correo = usuario.Correo;


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